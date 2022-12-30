namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        //Test props
        [Test]
        public void EmptyBookNameTest()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new Book("", "Pepi"));
        }

        [Test]
        public void EmptyAuthorOfBookTest()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new Book("Kniga", ""));
        }

        //Add footNote
        [Test]
        public void AddFootNoteWork()
        {
            Book book = new Book("Kniga", "Pepi");
            book.AddFootnote(3, "PRaseeee");

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void CantAddExistingFootNote()
        {
            Book book = new Book("Kniga", "Pepi");
            book.AddFootnote(3, "PRaseeee");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(3, "Gruh"));
        }

        //Find footNote
        [Test]
        public void FindFootNoteWork()
        {
            Book book = new Book("Kniga", "Pepi");
            book.AddFootnote(3, "PRaseeee");

            Assert.AreEqual($"Footnote #3: PRaseeee", book.FindFootnote(3));
        }

        [Test]
        public void BookDoesntContainsFootNote()
        {
            Book book = new Book("Kniga", "Pepi");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(5));
        }


        //Alter FootNote
        [Test]
        public void AlterFootNoteWork()
        {
            Book book = new Book("Kniga", "Pepi");
            book.AddFootnote(3, "PRaseeee");
            book.AlterFootnote(3, "gryh gryh");

            Assert.AreEqual($"Footnote #3: gryh gryh", book.FindFootnote(3));
        }

        [Test]
        public void CantAlterFootNoteIfBookDoesntContainFootNote()
        {
            Book book = new Book("Kniga", "Pepi");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(3, "kiki"));
        }
    }
}