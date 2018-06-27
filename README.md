#Book Stores-A Simple MVC Project

This is a simple Web Project I've created using the MVC framework for demonstration purposes.

##Main controllers and actions

The project has three controllers that control separate sections:

- Book
- Author
- Store

Each have three separate Actions:

- Add
- Details
- Index

###Add

The Add action takes you to a web form that allows you to add a new Item(Author, Book, Store) to the database (A Local SQL Database that's connected using entity framework).

The Add action consists of various textboxes, textareas, checkboxes, drop-down lists, and radio buttons each mapped to the Model using the HTML Helpers of the razor engine.

It should also be noted when you add a new book you can choose an author from a dropdown list that consists of all the authors in the database. If the author you are looking for is not present in the database you can choose the option "--- The author does not exist in the database --" which 
pops up another textbox (through the powe of JQuery) to add a custom author name.

Also each form item has it's on validation that's created using the Validation Data Annotations including:

- Required
- Range
- Regular Expression


![alt text](https://raw.githubusercontent.com/ljuben97/Book-Store/master/Images/AddAuthor.PNG)


###Details

The details action consists of all the information of a specific book, author and details.

Further more for the details of the book the system displays all the stores that the book is available for purchase and the book's price along with a "Buy" button.

Inside the details of the Author the system automatically calculates the author's age by subtracting the current date(if the author is still alive) or the date the author died(if the author is deceased) with the date of his/her birth. I also displays all the books written by that author with a "Details" button that navigates to the book's details.

Inside the details of a Store along with the store's full details you can also see all the books that are up for sale in the store along with the book's price, how many books are in stock and a "Buy" button once again.

![alt text](https://raw.githubusercontent.com/ljuben97/Book-Store/master/Images/StoreDetails.PNG)

###Index

The index action displays all the books, authors and stores displayed in a stylized fashion. Every item holds information abou it's title the image and further info depending on the type of item. Also every item holds a "Details" button that takes the user to the details section of the specified item.

![alt text](https://raw.githubusercontent.com/ljuben97/Book-Store/master/Images/BookDetailsPNG.PNG)

##Extra actions for the Store Controller

The store controller holds extra action including:

- Add a Book
- Buy a Book

###Add a Book

The add a book action takes the user to add a book to the specific store. The view for this action displays the store's information and generates a form that holds a drop-down list of all the books available a text field for the selected book's price and another text field for the number of books to add in the store. 

Once submitted the Post Action connects the book to the store by creating a link object that holds the store's id, the book's id, the price and the quantity and saves it to the database.

![alt text](https://raw.githubusercontent.com/ljuben97/Book-Store/master/Images/AddBook.PNG)

###Buy a Book

The buy a book action takes the user to the buy a book section for the specific's store. It displays the store's details, the book's details and a simple form that has a textfield for the number of book's the user likes to buy. 

With the help of JQuery everytime the text field for the quantity of the books changes the total price is being calculated by multiplying the book's price with the number of books and the number of remaining books changes by subtracting the number of remaining books with the number of books the user likes to buy. 

Of course if the number exceeds the number of books available the site will give an error and the "Buy" submit button will be deactivated. Further more if the user's enters a negative number the site will also give an error.

![alt text](https://raw.githubusercontent.com/ljuben97/Book-Store/master/Images/BuyBook.PNG)

Here is the code for the JQuery script:

```
<script>
    $(document).ready(function () {
        $("#quantity").on('input', function () {
            var quantity = $("#quantity").val();
            if (quantity < 0) {
                $("#available").css("color", "red");
                $("#available").html("Don't put a negative number!");
                $("#submit").prop('disabled', true);
            }
            else {
                var price =@Model.Price;
                var available =@Model.InStock-quantity;
                $("#total").html("Total price: " + quantity * price + " USD");
                if (available >= 0) {
                    $("#available").css("color", "black");
                    $("#available").html("Available Units: " + available);
                    $("#submit").prop('disabled', false);
                }
                else {
                    $("#available").css("color", "red");
                    $("#available").html("Not enough units available!");
                    $("#submit").prop('disabled', true);
                }
            }
        })
    })
</script>
```

##Future plans

I sincerelly hope you like this project. For the furutre I plan on adding a fully-functioning authentication and authorization system, Edit and Delete actions for all the controllers and polish up the css to make it look more clean and moder
