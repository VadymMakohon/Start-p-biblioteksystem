using Stateless;
using System;

namespace Biblioteksystem
{
    public enum BookStatus
    {
        Bestilt,
        Tilgjengelig,
        Utlånt,
        Reservert,
        Tapt
    }

    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }
        public BookStatus Status { get; private set; }

        private readonly StateMachine<BookStatus, string> _stateMachine;

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Status = BookStatus.Bestilt;

            _stateMachine = new StateMachine<BookStatus, string>(BookStatus.Bestilt);

            // Definerer statene og overganger
            _stateMachine.Configure(BookStatus.Bestilt)
                .Permit("Levering", BookStatus.Tilgjengelig);

            _stateMachine.Configure(BookStatus.Tilgjengelig)
                .Permit("Lån", BookStatus.Utlånt)
                .Permit("Tapt", BookStatus.Tapt);

            _stateMachine.Configure(BookStatus.Utlånt)
                .Permit("Reserver", BookStatus.Reservert)
                .Permit("Tapt", BookStatus.Tapt);

            _stateMachine.Configure(BookStatus.Reservert)
                .Permit("Tilbakelevert", BookStatus.Utlånt)
                .Permit("Tapt", BookStatus.Tapt);

            _stateMachine.Configure(BookStatus.Tapt)
                .Permit("Bestilt", BookStatus.Bestilt);
        }

        public void ChangeStatus(string trigger)
        {
            if (_stateMachine.CanFire(trigger))
            {
                _stateMachine.Fire(trigger);
                Status = _stateMachine.State;
            }
            else
            {
                throw new InvalidOperationException($"Ugyldig statusovergang fra {Status} med trigger: {trigger}");
            }
        }

        public override string ToString()
        {
            return $"Bok: {Title} av {Author}, Utgitt: {PublicationYear}, Status: {Status}";
        }
    }
}