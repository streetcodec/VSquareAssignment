# Overview
- This Game is about clicking and bursting balloons. The user gets a predetermined time to burst as many balloons as possible.
- The Game as an External Controller (ExternalController.py) which can be used to manipulate Vertical and Horizontal Velocities of the balloons.
- Has a main menu, leaderboard, gameplay and option to submit score to the leaderboard.
- The leaderboard is provided by integrating PlayFab.
- The Game has easy navigation between scenes.

# PlayFab Integration
- Playfab has been integrated by downloading it's unity sdk, then making a new Title. For leaderboard, a new leaderboard was created on PlayFab User Interface.
- In the script, first created a custom ID for the user by : ``` PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnError); ```
- Then created a function to Update the leaderboard by : ``` PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError); ```
- To show the leaderboard, used : ``` PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError); ```

# Python Integration
- Used Socket Library for both Python and C# scripts. Used UDP (User Datagram Protocol) for connection, through port 5052
- On Python side,
- ```
  sock = socket.socket(socket.AF_INET , socket.SOCK_DGRAM)
  serverAddressPort = ("127.0.0.1", 5052)
  ```
- On c# side, Receive.cs, there is code to Receive the data using :
  ```
    IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);
  ```
  # Setup for Python
  - Install Sockets
  ```
  pip install sockets
  ```
  - Run the python anywhere on the system, before or after execution of the game.
# Demo

https://github.com/streetcodec/VSquareAssignment/assets/92046906/30b463e2-f103-4394-b8b5-47a880d7ca35

