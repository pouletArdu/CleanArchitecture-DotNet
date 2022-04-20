namespace Application.Validation.Tests.StepDefinitions
{
    [Binding]
    public class CreateBookStepDefinitions
    {
        private BookRepositoryMock _repository;
        private CreateBookCommandHander _hander;
        private Book _book;
        private Book _result;
        private Exception _exception;

        public CreateBookStepDefinitions()
        {
            _repository = new BookRepositoryMock();
            _hander = new CreateBookCommandHander(_repository);
        }

        [Given(@"I have a new book to add")]
        public void GivenIHaveANewBookToAdd()
        {
            _book = new Book
            {
                Title = "Titre",
                Autor = new Autor
                {
                    FirstName = "André"
                }
            };
        }

        [When(@"I add the book")]
        public void WhenIAddTheBook()
        {
            try
            {
                _result = _hander.Handle(new CreateBookCommand(_book), CancellationToken.None).Result;

            }
            catch (Exception e)
            {

                _exception = e;
            }
        }

        [Then(@"The book is added")]
        public void ThenTheBookIsAdded()
        {
            Assert.AreEqual(_repository.GetAll().Result.First().Title, _book.Title);
        }

        [Given(@"I have a new book without title to add")]
        public void GivenIHaveANewBookWithoutTitleToAdd()
        {
            _book = new Book
            {
                Autor = new Autor
                {
                    FirstName = "André"
                },
                CreationDate = DateTime.Now

            };

        }

        [Then(@"An Error '([^']*)' is raised")]
        public void ThenAnErrorIsRaised(string errorMessage)
        {
            Assert.AreEqual(_exception.Message, errorMessage);
        }

        [Given(@"a list of book :")]
        public async void GivenAListOfBook(Table table)
        {
            foreach (var row in table.Rows)
            {
                await _repository.Create(new Book
                {
                    Title = row[0],
                    Autor = new Autor
                    {
                        FirstName = row[1]
                    },
                    CreationDate = DateTime.Now
                });
            }
        }

        [Given(@"I have a new book '([^']*)' to add")]
        public void GivenIHaveANewBookToAdd(string title)
        {
            _book = new Book
            {
                Title = title,
                Autor = new Autor
                {
                    FirstName = "Nathanaël"
                },
                CreationDate = DateTime.Now
            };
        }
    }
}
