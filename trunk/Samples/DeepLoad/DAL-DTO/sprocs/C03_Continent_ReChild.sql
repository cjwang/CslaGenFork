/****** Object:  StoredProcedure [GetC03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC03_Continent_ReChild]
GO

CREATE PROCEDURE [GetC03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO

/****** Object:  StoredProcedure [AddC03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC03_Continent_ReChild]
GO

CREATE PROCEDURE [AddC03_Continent_ReChild]
    @Continent_ID2 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID2,
            @Continent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC03_Continent_ReChild]
GO

CREATE PROCEDURE [UpdateC03_Continent_ReChild]
    @Continent_ID2 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2
        )
        BEGIN
            RAISERROR ('''C03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteC03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC03_Continent_ReChild]
GO

CREATE PROCEDURE [DeleteC03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2
        )
        BEGIN
            RAISERROR ('''C03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO
