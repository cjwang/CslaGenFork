/****** Object:  StoredProcedure [AddE06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE06_Country]
GO

CREATE PROCEDURE [AddE06_Country]
    @Country_ID int OUTPUT,
    @Parent_SubContinent_ID int,
    @Country_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @Parent_SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO

/****** Object:  StoredProcedure [UpdateE06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE06_Country]
GO

CREATE PROCEDURE [UpdateE06_Country]
    @Country_ID int,
    @Country_Name varchar(50),
    @Parent_SubContinent_ID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''E06_Country'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name,
            [Parent_SubContinent_ID] = @Parent_SubContinent_ID
        WHERE
            [Country_ID] = @Country_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO

/****** Object:  StoredProcedure [DeleteE06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE06_Country]
GO

CREATE PROCEDURE [DeleteE06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark E06_Country object as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
