# DVISApi
 DVIS HTTP API Windows Forms Example
 
 ## Instructions:
 * Input Server
 
 ![Input Server PNG](https://github.com/SheaCodes/DVISApi/blob/master/readme%20input%20server.png?raw=true)
 
 * Signal file should contain a list of signals
 
 ![Input Signal File PNG](https://github.com/SheaCodes/DVISApi/blob/master/readme%20signal%20file.png?raw=true)
 
 * Example signal file
 
 ![Example Signal File PNG](https://github.com/SheaCodes/DVISApi/blob/master/readme%20signal%20file%20example.PNG?raw=true)
 
 * If **Combine CSVs to One** is checked, one CSV will be created with data from all signals (similar to chart export, but in this case row frequency is calculated by examining the first 10 data points of all signals (rounded to the nearest 100, 250, 500, 1000ms).
 
 ![Combine CSVS to One PNG](https://github.com/SheaCodes/DVISApi/blob/master/readme%20combine%20csvs%20to%20one.png?raw=true)
 
 * If **Combine CSVs to One** is **not** checked, one CSV will be created for each signal


# Notes
- Backwards compatible with C# 6.0 (Visual Studio 2013)
