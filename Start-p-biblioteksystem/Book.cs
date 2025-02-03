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

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Status = BookStatus.Bestilt;
        }

        public void ChangeStatus(BookStatus newStatus)
        {
            if (IsValidStatusTransition(Status, newStatus))
            {
                Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException($"Ugyldig statusovergang fra {Status} til {newStatus}.");
            }
        }

        private bool IsValidStatusTransition(BookStatus currentStatus, BookStatus newStatus)
        {
            return (currentStatus == BookStatus.Bestilt && newStatus == BookStatus.Tilgjengelig) ||
                   (currentStatus == BookStatus.Tilgjengelig && (newStatus == BookStatus.Utlånt || newStatus == BookStatus.Tapt)) ||
                   (currentStatus == BookStatus.Utlånt && (newStatus == BookStatus.Reservert || newStatus == BookStatus.Tapt)) ||
                   (currentStatus == BookStatus.Reservert && newStatus == BookStatus.Utlånt) ||
                   (currentStatus == BookStatus.Tilgjengelig && newStatus == BookStatus.Tapt) ||
                   (currentStatus == BookStatus.Utlånt && newStatus == BookStatus.Tapt) ||
                   (currentStatus == BookStatus.Reservert && newStatus == BookStatus.Tapt);
        }

        public override string ToString()
        {
            return $"Bok: {Title} av {Author}, Utgitt: {PublicationYear}, Status: {Status}";
        }
    }
}