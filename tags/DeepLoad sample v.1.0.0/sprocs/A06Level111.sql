/****** Object:  StoredProcedure [AddA06Level111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA06Level111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA06Level111]
GO

CREATE PROCEDURE [AddA06Level111]
    @Level_1_1_1_ID int OUTPUT,
    @Level_1_1_ID int,
    @Level_1_1_1_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1 */
        INSERT INTO [Level_1_1_1]
        (
            [MarentID1],
            [Level_1_1_1_Name]
        )
        VALUES
        (
            @Level_1_1_ID,
            @Level_1_1_1_Name
        )

        /* Return new primary key */
        SET @Level_1_1_1_ID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1]
        WHERE
            [Level_1_1_1_ID] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [UpdateA06Level111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA06Level111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA06Level111]
GO

CREATE PROCEDURE [UpdateA06Level111]
    @Level_1_1_1_ID int,
    @Level_1_1_1_Name varchar(50),
    @MarentID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_ID] FROM [Level_1_1_1]
            WHERE
                [Level_1_1_1_ID] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''A06Level111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_ID] FROM [Level_1_1_1]
            WHERE
                [Level_1_1_1_ID] = @Level_1_1_1_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''A06Level111'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1 */
        UPDATE [Level_1_1_1]
        SET
            [Level_1_1_1_Name] = @Level_1_1_1_Name,
            [MarentID1] = @MarentID1
        WHERE
            [Level_1_1_1_ID] = @Level_1_1_1_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1]
        WHERE
            [Level_1_1_1_ID] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteA06Level111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA06Level111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA06Level111]
GO

CREATE PROCEDURE [DeleteA06Level111]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_ID] FROM [Level_1_1_1]
            WHERE
                [Level_1_1_1_ID] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''A06Level111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12Level111111 from Level_1_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1_1]
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A11Level111111ReChild from Level_1_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A11Level111111Child from Level_1_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A10Level11111 from Level_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1]
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A09Level11111ReChild from Level_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A09Level11111Child from Level_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A08Level1111 from Level_1_1_1_1 */
        DELETE
            [Level_1_1_1_1]
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A07Level1111ReChild from Level_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete child A07Level1111Child from Level_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_Child]
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

        /* Delete A06Level111 object from Level_1_1_1 */
        DELETE
        FROM [Level_1_1_1]
        WHERE
            [Level_1_1_1].[Level_1_1_1_ID] = @Level_1_1_1_ID

    END
GO
