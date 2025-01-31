# ConsoleBasedAIApplication
In the task for High Distinction, I created a simple yet powerful console-based application where, the user can talk to the AI with the help of API. There are ample of Free API available, I chode Hugging Face as I planned to implement an interactive and talking AI, and with the help of Hugging Face’s Blenderbot model. 
The program is implemented in C# where, the asynchronous function is the function that does all the heavy lifting. Initially, with the help of “using”, an HttpClient  is made to handle all the get and post requests to the server of the Hugging Face’s Blenderbot model. To retrieve the data from the server, we use GET method whereas to post the user data to the server, we use POST method. 
The async (Asynchronous) functions are used which are used so that the functions are performed independently while the await keyword tell the cursor for to wait for the main thread to execute. The async and await functions are used in the code for the same functionality/reason; since there is an await call for the GetHuggingFaceResponse function to return the output in the form of the answer to the user’s question, the Main function is also a asynchronous function. These asynchronous functions are basically used when a single line of code can take more time or an amount of time which is unknown for the user. 
	Consider the following example – 
 ![Image](https://github.com/user-attachments/assets/99c53cd5-ca60-48f3-8e8f-f00f5069e822)
 
Figure 1. Asynchronous Function Example
In the example given above, an asynchronous function is given where, there are different tasks which come under Morning Routine. These include-
1.	Taking a shower
2.	Having coffee
3.	Putting on clothes
4.	Be ready
5.	Fill gas
All these tasks are independent of each other yet, the time required for each of these is not fixed and may vary every day. Hence, these tasks are appended with an “await” keyword meaning, the cursor will wait until one task is finished, then move on to the next one. 
In the context of the application, the asynchronous functions and async-await are used - 

    	static async Task Main()
    	{
		<Program logic here>
            	string response = await GetHuggingFaceResponse(userInput);
            	Console.WriteLine("AI: " + response);
        }

Similarly, the await for the is also used so that the HttpClient is made and then the program processes further. 

	static async Task<string> GetHuggingFaceResponse(string prompt)
	    {
	                HttpResponseMessage response = await client.PostAsync(API_URL, content);
	    }
	
TO hit the Hugging Face with the API, we need an HttpClient to hit the POST requests. Initially, a HttpClient is made with the help of using keyword. The using keyword is used in the program for an efficient resource management. These resources may include – 
1.	Files
2.	Database connections
3.	Http Requests and many more
The using keyword, specifically, is used for an IDisposable resources where, after the use of the resource, the resource is disposed by calling the Dispose() method.

![Image](https://github.com/user-attachments/assets/4b50ff78-d90c-43c3-bb72-a817984cbd68) 

In the above code snippet, the file named “TestFile.txt” is read with the help of StreamReader class, the contents of the file are stored in the line variable and after the cursor exits the while loop, the “TestFile.txt” is Disposed() as it is of no use and hence, the file resource is efficiently managed and used.
Here within the code, the using keyword is used to initialize the HttpClient, POST the request to the AI with the help of API and get the response from the AI. 
The POST request given to the Hugging face must have the parameters in Json format, that is, in a key value pair. Initially, we have to do Serialization of the asynchronous so that it can be interpreted at the time of API request. Serialize is a method where we convert the objects of a datatype to JSON as the APIs accepts the JSON formats. The full code for the console-based application where the user can interact with the AI, with the help of API (Application Programming Interface). 

![Image](https://github.com/user-attachments/assets/98b292aa-c1f6-4ae9-a5de-55e58bffbbe7)

This is how the serialization takes place, and the data is converted accordingly. Within the application code, a object named requestBody is made with the field as “inputs” and the value of the field as “prompt”, which is taken from the user.
On the other hand, the Deserialize operation is performed to convert the JSON data back to object. Within this JSON data, the “generated_text” is extracted, which has the required answer to the user prompt. 
Additionally, the data given as response can either be in a form of JObject or JArray. Depending on the response, the required answer is extracted from the response with the help of error handling, with the help of try catch block.
The try catch block basically has two block – 
1.	A try block, where, the logic within the block or the code written within the block can given an error. If there is no error thrown by the block, it dosen’t skip any part and the code is executed sequentially; but if the try block throws an error, it is catch block and the program is executed in a non-sequential manner.
2.	A catch block, which is executed when the try block throws an error and it is caught  by the catch block.
The traditional structure of a try-catch block is given as -

![Image](https://github.com/user-attachments/assets/35e2f6bb-e71e-40db-b9d1-d1f9fb3a0a49)

With the application code, the error handling is performed as – 

	try
	                {
	                    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(responseBody);
	                    <Program logic here>                }
	                catch
	                {
	                    // If deserialization fails as JObject, try as JArray (array)
	                    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(responseBody);
	<Program logic here>               
	 }

The OneDrive link for the link to whole program file: 
https://deakin365-my.sharepoint.com/my?id=%2Fpersonal%2Fs224970276%5Fdeakin%5Fedu%5Fau%2FDocuments%2FConsole%20Based%20Application%20using%20Hugging%20Face%20API

Resources – 
•	https://github.com/huggingface/unity-api/blob/main/README.md
•	https://github.com/tryAGI/HuggingFace/blob/main/README.md
•	https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using
•	https://www.bytehide.com/blog/using-keyword-csharp
•	https://d2l.deakin.edu.au/d2l/le/content/1423595/viewContent/7644013/View
•	https://huggingface.co/docs/api-inference/en/index


The link to OneDrive for Video Explanation of the application - 
https://deakin365-my.sharepoint.com/personal/s224970276_deakin_edu_au/_layouts/15/stream.aspx?id=%2Fpersonal%2Fs224970276%5Fdeakin%5Fedu%5Fau%2FDocuments%2FApplication%20Explanation%20Video%2Emp4&referrer=StreamWebApp%2EWeb&referrerScenario=AddressBarCopied%2Eview%2E57d04b3c%2D0566%2D4cc5%2Dbf68%2D013ec49485ed
 
