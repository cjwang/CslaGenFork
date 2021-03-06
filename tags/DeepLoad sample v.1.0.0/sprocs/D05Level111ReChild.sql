/****** Object:  StoredProcedure [GetD05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD05Level111ReChild]
GO

CREATE PROCEDURE [GetD05Level111ReChild]
    @CMarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[CMarentID2] = @CMarentID2

    END
GO

/****** Object:  StoredProcedure [AddD05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD05Level111ReChild]
GO

CREATE PROCEDURE [AddD05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_ReChild]
        (
            [CMarentID2],
            [Level_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_ID,
            @Level_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD05Level111ReChild]
GO

CREATE PROCEDURE [UpdateD05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID
        )
        BEGIN
            RAISERROR ('''D05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_ReChild */
        UPDATE [Level_1_1_1_ReChild]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteD05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD05Level111ReChild]
GO

CREATE PROCEDURE [DeleteD05Level111ReChild]
    @Level_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID
        )
        BEGIN
            RAISERROR ('''D05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D05Level111ReChild object from Level_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[CMarentID2] = @Level_1_1_ID

    END
GO
