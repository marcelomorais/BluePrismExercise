# BluePrismExercise

This project has a appsettings.json where you can edit the *file directories*, they are:
```DictionaryPath and ResultPath```

If you don't change anything, this application will read from the dictionary first provided with name "word-english.txt" and the result path will be inside the ```bin/``` folder in the file ```result.txt```

To execute the project open the main folder in your CMD and write:

```BluePrismExercise.exe StartWord EndWord```
example:
```BluePrismExercise.exe SPIN SPOT```


Improvement areas:

Create Integration tests

Decrease the amount of private methods in order to be more testable

Create more unit tests to cover edge cases

Separate the SERVICE in a different .csproj making it more scalable.

Use a bit less redundancy to be easier to read.


Obs:

I just published everything in the main folder to be easier for who will test this application, please don't consider it in your avaliation.
