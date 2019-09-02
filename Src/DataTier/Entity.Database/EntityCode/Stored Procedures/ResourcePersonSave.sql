﻿Create Procedure [EntityCode].[ResourcePersonSave]
    @Id             	int,
    @Key				uniqueidentifier,
	@FirstName			nvarchar(50),
	@MiddleName			nvarchar(50),
	@LastName			nvarchar(50),
	@BirthDate			datetime,
	@GenderId			int,
	@ActivityContextKey	Uniqueidentifier
AS
	-- Local variables
    Declare @ResourceKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
    Declare @PersonKey As Uniqueidentifier = '00000000-0000-0000-0000-000000000000'
	-- Initialize
	Select	@Key			= IsNull(@Key, '00000000-0000-0000-0000-000000000000')
	Select 	@FirstName		= RTRIM(LTRIM(@FirstName))
	Select 	@MiddleName		= RTRIM(LTRIM(@MiddleName))
	Select 	@LastName		= RTRIM(LTRIM(@LastName))
	
	-- Validate data that will be inserted/updated, and ensure basic values exist
	If ((@FirstName <> '') Or (@MiddleName <> '') Or (@LastName <> '')) And (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
        If (@Id <> -1) Select Top 1 @Key = IsNull(ResourcePersonKey, @Key), @ResourceKey = ResourceKey, @PersonKey = PersonKey From [Entity].[ResourcePerson] P Where [ResourcePersonId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(ResourcePersonId, -1), @ResourceKey = ResourceKey, @PersonKey = PersonKey From [Entity].[ResourcePerson] P Where [ResourcePersonKey] = @Key
		-- Insert vs Update
		
		Begin Try
			If (@Id Is Null) Or (@Id = -1)
			Begin
				-- Create main entity record
				Select @PersonKey = IsNull(NullIf(@PersonKey, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[Entity] (EntityKey) Values (@PersonKey)
				-- Create person record
				Insert Into [Entity].[Person] (PersonKey, FirstName, MiddleName, LastName, BirthDate, GenderId, RecordStateKey, CreatedActivityKey, ModifiedActivityKey)
					Values (@PersonKey, @FirstName, @MiddleName, @LastName, @BirthDate, @GenderId, '00000000-0000-0000-0000-000000000000', @ActivityContextKey, @ActivityContextKey)
                -- Create Resource record
                Select @ResourceKey = IsNull(NullIf(@ResourceKey, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[Resource] (ResourceKey, RecordStateKey, CreatedActivityKey, ModifiedActivityKey)
                    Values (@ResourceKey, '00000000-0000-0000-0000-000000000000', @ActivityContextKey, @ActivityContextKey)
                -- Create ResourcePerson record
				Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
				Insert Into [Entity].[ResourcePerson] (ResourcePersonKey, ResourceKey, PersonKey, RecordStateKey, CreatedActivityKey, ModifiedActivityKey) 
                    Values (@Key, @ResourceKey, @PersonKey, '00000000-0000-0000-0000-000000000000', @ActivityContextKey, @ActivityContextKey)
				Select	@Id = SCOPE_IDENTITY()
			End
            Else
			Begin
				-- Create main entity record
				Update P
				Set P.FirstName				= @FirstName, 
					P.MiddleName			= @MiddleName, 
					P.LastName				= @LastName, 
					P.BirthDate				= @BirthDate, 
					P.GenderId			= @GenderId,
					P.ModifiedActivityKey	= @ActivityContextKey,
					P.ModifiedDate			= GetUTCDate()
				From	[Entity].[Person] P
				Where	P.PersonKey = @PersonKey
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
			
		End Catch
	End	

	-- Return data
	Select	IsNull(@Id, -1) As [Id], IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
