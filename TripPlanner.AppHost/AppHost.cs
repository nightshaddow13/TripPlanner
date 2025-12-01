var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TripPlanner>("tripplanner");

builder.Build().Run();
