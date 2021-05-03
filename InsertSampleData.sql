INSERT INTO CommandItems (HowTo, Platform, CommandLine)
VALUES (
        'Create an EF migration',
        'Entity FrameworkCore CommandLine',
        'dotnet ef migrations add'
       ),
       (
        'Apply Migrations to DB',
        'Entity FrameworkCore CommandLine',
        'dotnet ef database update'
       );