/****** Object:  StoredProcedure [GetH07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH07_Country_Child]
GO

CREATE PROCEDURE [GetH07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1 AND
            [3_Countries_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH07_Country_Child]
GO

CREATE PROCEDURE [AddH07_Country_Child]
    @Country_ID1 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID1,
            @Country_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateH07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH07_Country_Child]
GO

CREATE PROCEDURE [UpdateH07_Country_Child]
    @Country_ID1 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteH07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH07_Country_Child]
GO

CREATE PROCEDURE [DeleteH07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
