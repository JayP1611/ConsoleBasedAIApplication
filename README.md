# ConsoleBasedAIApplication
This is a console based application where, the user can talk to the AI with the help of API calls. I chose to go with the "Hugging Face" AI which has the "Blenderbot" model. This model is more suited for applications where the user chats with the AI. 

In the task for High Distinction, I created a simple yet powerful console-based application where, the user can talk to the AI with the help of API. There are ample of Free API available, I chode Hugging Face as I planned to implement an interactive and talking AI, and with the help of Hugging Face’s Blenderbot model. 
	The program is implemented in C# where, the asynchronous function is the function that does all the heavy lifting. Initially, with the help of “using”, an HttpClient  is made to handle all the get and post requests to the server of the Hugging Face’s Blenderbot model. To retrieve the data from the server, we use GET method whereas to post the user data to the server, we use POST method. 
	The async (Asynchronous) functions are used which are used so that the functions are performed independently while the await keyword tell the cursor for to wait for the main thread to execute. The async and await functions are used in the code for the same functionality/reason; since there is an await call for the GetHuggingFaceResponse function to return the output in the form of the answer to the user’s question, the Main function is also a asynchronous function. 
 
    static async Task Main()
    {
	<Program logic here>
            string response = await GetHuggingFaceResponse(userInput);
            Console.WriteLine("AI: " + response);
        }
    }
    
Similarly, the await for the is also used so that the HttpClient is made and then the program processes further. 

	static async Task<string> GetHuggingFaceResponse(string prompt)
    	{
                	HttpResponseMessage response = await client.PostAsync(API_URL, content);
    	}


Next in the program, the HuggingFace might give a response in either as a JObject or JSON format, the error handling is done accordingly. 

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

Serialize is a method where we convert the objects of a datatype to JSON as the APIs accepts the JSON formats. The full code for the console-based application where the user can interact with the AI, with the help of API (Application Programming Interface). 

The link to OneDrive for Video Explanation of the application - 

https://deakin365-my.sharepoint.com/personal/s224970276_deakin_edu_au/_layouts/15/stream.aspx?id=%2Fpersonal%2Fs224970276%5Fdeakin%5Fedu%5Fau%2FDocuments%2FApplication%20Explanation%20Video%2Emp4&referrer=StreamWebApp%2EWeb&referrerScenario=AddressBarCopied%2Eview%2Ef76a44ba%2Da543%2D45a2%2Dadb9%2D5da03c7fe2af
 
