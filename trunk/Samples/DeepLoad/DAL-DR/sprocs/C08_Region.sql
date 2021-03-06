/****** Object:  StoredProcedure [AddC08_Region] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC08_Region]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC08_Region]
GO

CREATE PROCEDURE [AddC08_Region]
    @Region_ID int OUTPUT,
    @Parent_Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Parent_Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateC08_Region] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC08_Region]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC08_Region]
GO

CREATE PROCEDURE [UpdateC08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC08_Region] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC08_Region]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC08_Region]
GO

CREATE PROCEDURE [DeleteC08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete C08_Region object from 4_Regions */
        DELETE
        FROM [4_Regions]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
