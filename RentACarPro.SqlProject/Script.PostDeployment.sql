/*
    Prepared data for the first publish.
*/

IF NOT EXISTS (SELECT * FROM dbo.Brands)
BEGIN
    INSERT INTO dbo.Brands([Name])
    VALUES ('Mercedes'),
           ('Toyota'),
           ('BMW')
END

IF NOT EXISTS (SELECT * FROM dbo.Series)
BEGIN
    INSERT INTO dbo.Series([BrandId], [Name])
    VALUES (1, 'A-class'),
           (1, 'S-class'),
           (3, '5-series'),
           (3, 'X-series')
END

IF NOT EXISTS (SELECT * FROM dbo.Models)
BEGIN
    INSERT INTO dbo.Models([BrandId], [SeriesId], [Name])
    VALUES (1, NULL, '170V'),
           (1, 1, 'A 170'),
           (1, 1, 'A 190'),
           (1, 2, 'S 250'),
           (1, 2, 'S 280'),
           (2, NULL, 'Auris'),
           (2, NULL, 'Camry'),
           (3, 3, '530e'),
           (3, 4, 'X6')
END

IF NOT EXISTS (SELECT * FROM dbo.Colors)
BEGIN
    INSERT INTO dbo.Colors([Name])
    VALUES ('Black'),
           ('White'),
           ('Silver'),
           ('Light Blue')
END

IF NOT EXISTS (SELECT * FROM dbo.Cars)
BEGIN
    INSERT INTO dbo.Cars([BrandId], [ModelId], [ColorId], [ModelYear], [DailyPrice], [Description])
    VALUES (1, 1, 1, 1935, 750000, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (1, 2, 2, 1999, 6500, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (1, 3, 3, 2005, 9000, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (1, 4, 4, 2002, 7500, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (1, 5, 1, 2010, 12900, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (2, 6, 2, 2011, 14000, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (2, 7, 3, 2007, 11500, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (3, 8, 4, 2018, 24500, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.'),
           (3, 9, 1, 2013, 15900, 'Pellentesque ac ex ac orci pretium tristique. Aenean et suscipit risus. Aenean scelerisque mauris non turpis fringilla tempor. Aliquam sit amet dui sit amet neque ullamcorper rhoncus et et lorem.')
END