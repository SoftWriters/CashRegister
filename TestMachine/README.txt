Hello. Thanks for looking at my code. This problem was LOTS of fun. I really enjoyed the quirks that needed to be worked out.
This code was written as an example. Of course the code could have been made a lot simpler.
However, I wanted to demonstrate some approaches that produce good code. What might they be...I am glad that you asked.

1) It uses dependency injection (StructureMap specifically).  StructureMap is a bit old, but does what I needed and is reliable.
   Dependency injection allows two things: 1) easier unit testing 2) easier exchange of units within the application.
   The application is built from a series of parts. In this case, I used the default scanning which registered IBlob to Blob : IBlob. 
2) Unit testing. This is my favor part. I found so many errors in my code this way. Did you know that 3.33 % 3 is NOT equal zero? 
   I toyed with using MSpec for unit testing...but decided on MS test. I used MS Test for unit test because I wanted to try out 
   the VS Ultimate code lens. It's pretty sweet and definitely gives one a nice dashboard to work with. I used both state based
   testing and behavior based testing. I really like the arrange, act and assert method of setting up the unit tests. 
3) WHERE ARE ALL THE COMMENTS. I used them sparingly. If the code is written well with useful names of classes, methods and 
   variables…then less text is needed to help the reader. This keeps the code and comments from getting out of sync when refactoring.
4) Used SOLID, where applicable. Mostly, I used Single Responsibility and Open-Closed. I good example of Open-Closed is where I 
   refactored the currency from a fixed list to the classes. This would allow me to add additional currency (like FiveDollar, TenDollar,
   50cent, etc) or a whole new currency. The Money class is not very OpenClosed, but it was the glue to hold it together.
5) I don't want to forget extension methods, generics and exception handling too.

What does it do?
Well, it takes an input file that contains an item cost and payment as a number. Then, it gives back the change in a separate file. It logs information to stdout as it processes. Also, it does not stop if I line fails validation, it whines about it in the log and continues processing.
One last thing, if the item cost is divisible by three, it randomizes the currency it uses.

How do I run it.
CashMachine <inputFile> <OutputFile>
If the input file is not specified it uses the default provided. If the output is not provided then it uses the default provided.
