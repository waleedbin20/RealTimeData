# **RealTimeData**

**Current Situation** 

There is a customer-facing application called myapetito which gets some of its data from SAP. This data is collected twice a day at 8pm and 2am from SAP and exported to a separate database. This means that data our customers see can often be out of date. This causes problems for them and has the knock-on effect of causing operational challenges for our teams in Portbury, both in customer services and distribution 

 

**Solution Designed**  

Using the technologies I have designed a proof of concept which **get data out of SAP as changes are made, in real time**, where customers always see the same data as our internal SAP users.


# **Pre Requsites**
- Install Visual Studio
- .NET Framework (MVC Design pattern)
- PostgreSql


The Web API is hosted on Azure and can be viewed here: [Swagger](https://realtimedata.azurewebsites.net/index.html)

Client site can be viewed here: [Real Time client](https://waleedclient.azurewebsites.nethttps://waleedclient.azurewebsites.net)


# **Technology used**

**apigee**
apigee is an API management tool which we can use to monitor traffic for all the requests coming in before it is send to our backend services. 

**Signal R**
Today's modern apps are expected to deliver up-to-date information without hitting a refresh button. Add real-time functionality to our dashboards, maps, games and chat rooms and many more.
Real-time functionality is the ability to have your server-side code push content to connected clients as it happens, in real-time.


# **Proof of Concept**

Following is the flow chart how of the data being flown

![image-20220111-151124](https://user-images.githubusercontent.com/76840465/179399239-0f86dbb4-b942-4b01-a0a4-925030aabe7d.png)


# **Demo using postman**

https://user-images.githubusercontent.com/76840465/179400504-568350c3-c312-43c1-ac71-e59abe7fe069.mp4





