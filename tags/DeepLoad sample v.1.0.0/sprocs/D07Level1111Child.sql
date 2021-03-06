/****** Object:  StoredProcedure [GetD07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD07Level1111Child]
GO

CREATE PROCEDURE [GetD07Level1111Child]
    @CLarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_Child].[CLarentID1] = @CLarentID1

    END
GO

/****** Object:  StoredProcedure [AddD07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD07Level1111Child]
GO

CREATE PROCEDURE [AddD07Level1111Child]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_Child */
        INSERT INTO [Level_1_1_1_1_Child]
        (
            [CLarentID1],
            [Level_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_ID,
            @Level_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD07Level1111Child]
GO

CREATE PROCEDURE [UpdateD07Level1111Child]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''D07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_Child */
        UPDATE [Level_1_1_1_1_Child]
        SET
            [Level_1_1_1_1_Child_Name] = @Level_1_1_1_1_Child_Name
        WHERE
            [CLarentID1] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteD07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD07Level1111Child]
GO

CREATE PROCEDURE [DeleteD07Level1111Child]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''D07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D07Level1111Child object from Level_1_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_Child].[CLarentID1] = @Level_1_1_1_ID

    END
GO
