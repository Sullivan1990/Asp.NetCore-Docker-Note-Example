## Spinning up SQL Server on Docker (linux container)

### Set up the container

+ configure the docker-compose file, setting the password and taking note of the ports
+ from within the same folder, run:
<code>
    docker-compose up -d
</code>
+ This will download the required SQL Server image and spin up the container
+ The container can be shut down with:
<code>
    docker-compose down
</code>

### Connect to the Container

+ retrieve your container name using <code>docker ps</code>
+ running the following command, with the container name replaced with your container name
<code>
    docker exec -it 'container name' "bash"
</code>
+ with this you will be connected to the container - this is just to test it is working

### Set up .NET Project

+ set up a dotnet project as usual, with the following connection string (depending on your chosen password + port) </br>
  <code>"Server=127.0.0.1,1433;Database=NoteDB;User=sa;Password=abc_1234"</code>
+ after setting up the context, migrating and updating the database your application should be connected to the SQL Docker instance

### Connecting with SSMS

+ The Docker instance can be accessed via SSMS by providing the server address (as was provided in the connection string) and the username and password
  </br>
  <code>
    Server: 127.0.0.1,1433, Username: sa, Password: abc_1234
  </code>

