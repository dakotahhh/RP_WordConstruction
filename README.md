# RP_WordConstruction

Word Construction
A Word can be constructed using the following process:
Start with any letter
Add any letter to the beginning, the ending, or in between any existing letters
Repeat step 2
Given a set of valid Words, write a function in C# to determine the longest continuous set of valid words that can be generated using the above process.
For example, given a set of valid words { a, bb, ab, bbb, bab, bbbb }:
Start with the letter a forming the word a which is a valid word.
The set of valid words is { a }
Add the letter b to the end of the word a forming the word ab which is a valid word.
The set of valid words is { a, ab }
Add the letter b to the beginning of the word ab forming the word bab which is a valid word.
The set of valid words is { a, ab, bab }
The longest set is { a, ab, bab }
A longer set { b, bb, bbb, bbbb } can be formed using the process but contains the word b, which is not valid.
