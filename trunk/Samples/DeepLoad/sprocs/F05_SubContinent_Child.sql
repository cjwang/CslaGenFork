/****** Object:  StoredProcedure [AddF05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF05_SubContinent_Child]
GO

CREATE PROCEDURE [AddF05_SubContinent_Child]
    @SubContinent_ID1 int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID1,
            @SubContinent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF05_SubContinent_Child]
GO

CREATE PROCEDURE [UpdateF05_SubContinent_Child]
    @SubContinent_ID1 int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteF05_SubContinent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF05_SubContinent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF05_SubContinent_Child]
GO

CREATE PROCEDURE [DeleteF05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F05_SubContinent_Child object as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1

    END
GO
