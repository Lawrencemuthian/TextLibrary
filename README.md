# TextLibrary
Text Processing Library Implementation

# Challenge Description:
Task is to implement part of a text processing library.
The following are assumptions and definitions that limit the scope of the task: <br>
 - **Word:** To simplify, a word is represented by a sequence of one or more characters between 'a' and 'z' or between 'A' and 'Z'). For example 'agdfBh'. 
 - **Letter Case:** When counting frequencies, we are interested in the case insensitive frequency (i.e. in the text 'The sun shines over the lake', the library should count 2 occurrences for any of the words 'the' or 'The' or 'tHE' etc). 
 - **Input Text:** The input text contains words separated by various separator characters. Note that the characters from 'a' and 'z' and from 'A' and 'Z' can only appear within words. 
 - **Available Memory:** There is enough memory to store the whole input text.

![](https://github.com/Lawrencesoft/TextLibrary/blob/main/Images/Requirement.JPG)


Implement the three methods defined in this interface
 - CalculateHighestFrequency should return the highest frequency in the text (several words might actually have this frequency)
 - CalculateFrequencyForWord should return the frequency of the specified word
 - CalculateMostFrequentNWords should return a list of the most frequent 'n' words in the input text, all the words returned in lower case. If several words have the same frequency, this method should return them in ascendant alphabetical order (for input text 'The sun shines over the lake' and n = 3, it should return the list { ('the', 2), ('lake', 1), ('over', 1) }



# Required version and Technologies
  .NET 5.0 version
  Visual Studio 2019 IDE
- C# Core Web API
- Test cases created separately
- Added Dependancy Injection
- Added Swagger - Easy to invoke API

# Build and Run the Repository
Build any .NET Core project using the .NET Core CLI, which is installed with the [.NET Core SDK](https://dotnet.microsoft.com/download). Then run these commands from the CLI in the directory of this project:<br />

``dotnet build``<br />
``dotnet run``<br />

These will install any needed dependencies, build the project, and run the project respectively.  

**Other Options** - 
1) **Buid :** Open the Visual Studio(2022) IDE **Build**  Menu --> **Build solution**
2) **Run :** Open the [Sample.TextLibrary.sln](https://github.com/Lawrencesoft/TextLibrary/blob/main/Sample.TextLibrary.sln) in Visual Studio(2022) IDE and make the [Sample.TextLibrary.API](https://github.com/Lawrencesoft/TextLibrary/blob/main/Sample.TextLibrary/Sample.TextLibrary.API.csproj) as startup project and execute it or publish the API project in IIS and execute from there(Attached the screenshot below). 

**Publish :** Open the Visual Studio(2019) IDE **Build**  Menu --> **Publish Sample.TextLibrary** <br />
&nbsp;&nbsp;&nbsp;&nbsp;Select the path to publish it. Once it is publish to the path, This path can be link from IIS and run from there <br />

**Test Project Execution:** Open the Visual Studio(2019) IDE **Test**  Menu --> Run All Tests<br />
    Once it is executed, Test explorer will show the test results(Executed screenshot added below) 


# ScreenShots
![image](https://user-images.githubusercontent.com/63959021/159144797-f70396aa-11c4-4eef-8340-a86f9533acf8.png)
![image](https://user-images.githubusercontent.com/63959021/159144813-beea61e6-ec8e-4348-b415-0728b9ee7ee6.png)
![image](https://user-images.githubusercontent.com/63959021/159144844-84324eb3-cf12-48b9-8ce2-0dd5ce51bf27.png)
![image](https://user-images.githubusercontent.com/63959021/159144871-e2278534-2963-445d-bc92-a41be395023d.png)
![image](https://user-images.githubusercontent.com/63959021/159144898-308f2cae-39cd-4f6e-a29d-fc9854bcb3a8.png)


# Test Case Status
![image](https://user-images.githubusercontent.com/63959021/159144781-fb76091f-9db8-4736-9f8a-fdf4f5d745cf.png)

