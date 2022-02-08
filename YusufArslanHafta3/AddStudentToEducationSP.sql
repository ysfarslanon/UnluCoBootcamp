CREATE PROCEDURE AddStudentToLesson(@studentID int,	@educationID int)
AS
BEGIN


IF NOT EXISTS(SELECT * FROM Students WHERE ID=@studentID)
BEGIN
raiserror('Kayýtlý öðrenci yok',1,1)
END

ELSE IF NOT EXISTS(SELECT * FROM Educations WHERE ID=@educationID)
BEGIN
raiserror('Kayýtlý eðitim yok',1,1)
END

ELSE IF(
	(SELECT COUNT(*)
	FROM StudentInEducation AS SE
	INNER JOIN Students AS S
	ON SE.StudentId=S.ID
	INNER JOIN Educations AS E
	ON SE.EducationId=E.ID
	WHERE E.StartDate >= (SELECT StartDate FROM Educations WHERE ID=1) 
						AND 
						E.EndDate<=(SELECT StartDate FROM Educations WHERE ID =1))=0	)
BEGIN
	INSERT INTO StudentInEducation 
	VALUES (@studentID,@educationID)
END
ELSE
BEGIN
	raiserror('Öðrencinin kayýtlý eðitimi sürmektedir.',1,1)
END




END

--EXEC AddStudentToLesson 33,1
--EXEC AddStudentToLesson 2,1
--EXEC AddStudentToLesson 1,3
