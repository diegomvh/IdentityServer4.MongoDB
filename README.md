# MongoDb Persistence for IdentityServer4 #

**Current status: Beta**

This package supports the IdentityServer functionality.

## Usage ##

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection("MongoDbRepository");

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddConfigurationStore(config)
                .AddOperationalStore(config);
        }
    }


## Base on implementation of EntityFramework's support ##
 - [Identity Server v4 EntityFramework](https://github.com/IdentityServer/IdentityServer4.EntityFramework)

## And the good practices of ## 
 - [IdentityServer v3 MongoDb](https://github.com/jageall/IdentityServer.v3.MongoDb)

## Credits ##
MongoDb Persistence for IdentityServer is built using the following open source projects:
- [Identity Server v4](https://github.com/IdentityServer/IdentityServer4)
- [MongoDb](http://www.mongodb.org/)
- [MongoDb C# Driver](https://github.com/mongodb/mongo-csharp-driver)
- [xUnit](https://github.com/xunit)