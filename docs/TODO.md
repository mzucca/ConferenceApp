# TODOs
1. Create Appointments repository
2. Add repository tests
3. Add mail sender services
4. Complete registration process
5. Complete client registration
6. Complete Doctor registration 
3. Add Jwt Authentication Tests https://github.com/dotnet-labs/JwtAuthDemo/tree/main/webapi/JwtAuthDemo.IntegrationTests 
4. Integrate Jwt in authentication API  (AuthAPI)

FIx these warnings

[15:41:21 DBG] An additional 'IServiceProvider' was created for internal use by Entity Framework. An existing service provider was not used due to the following configuration changes: configuration changed for 'Core:ConfigureWarnings', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:UseAdminDatabase', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:SetPostgresVersion', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:UseRedshift', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:ReverseNullOrdering', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:RemoteCertificateValidationCallback', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:ProvideClientCertificatesCallback', configuration added for 'Npgsql.EntityFrameworkCore.PostgreSQL:ProvidePasswordCallback'.
[15:41:22 DBG] No relationship from 'Notification' to 'User' has been configured by convention because there are multiple properties on one entity type - {'Sender'} that could be matched with the properties on the other entity type - {'NotificationsForUser', 'NotificationsFromUser'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] No relationship from 'User' to 'Notification' has been configured by convention because there are multiple properties on one entity type - {'NotificationsForUser', 'NotificationsFromUser'} that could be matched with the properties on the other entity type - {'Sender'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] No relationship from 'User' to 'Notification' has been configured by convention because there are multiple properties on one entity type - {'NotificationsForUser', 'NotificationsFromUser'} that could be matched with the properties on the other entity type - {'Sender'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] No relationship from 'Notification' to 'User' has been configured by convention because there are multiple properties on one entity type - {'Sender'} that could be matched with the properties on the other entity type - {'NotificationsForUser', 'NotificationsFromUser'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] The property 'Appointment.ClientId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] The property 'Conference.DoctorId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] The property 'DiscountCoupon.ClientId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] The property 'Notification.UserId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] Entity Framework Core 8.0.4 initialized 'PostgresDbContext' using provider 'Npgsql.EntityFrameworkCore.PostgreSQL:8.0.4+51faf6e9c9c7ef99c3e98d98a96adb8fa8ae4553' with options: MigrationsAssembly=ReHub.DbDataModel
[15:41:22 DBG] No relationship from 'Notification' to 'User' has been configured by convention because there are multiple properties on one entity type - {'Sender'} that could be matched with the properties on the other entity type - {'NotificationsForUser', 'NotificationsFromUser'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] No relationship from 'User' to 'Notification' has been configured by convention because there are multiple properties on one entity type - {'NotificationsForUser', 'NotificationsFromUser'} that could be matched with the properties on the other entity type - {'Sender'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] No relationship from 'User' to 'Notification' has been configured by convention because there are multiple properties on one entity type - {'NotificationsForUser', 'NotificationsFromUser'} that could be matched with the properties on the other entity type - {'Sender'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] No relationship from 'Notification' to 'User' has been configured by convention because there are multiple properties on one entity type - {'Sender'} that could be matched with the properties on the other entity type - {'NotificationsForUser', 'NotificationsFromUser'}. This message can be disregarded if explicit configuration has been specified in 'OnModelCreating'.
[15:41:22 DBG] The property 'Appointment.ClientId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] The property 'Conference.DoctorId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] The property 'DiscountCoupon.ClientId' was created in shadow state because there are no eligible CLR members with a matching name.
[15:41:22 DBG] The property 'Notification.UserId' was created in shadow state because there are no eligible CLR members with a matching name.