CREATE VIEW GetStudentByEducation AS
SELECT E.Name AS Eðitim, S.FirstName AS Ad, S.LastName AS Soyad
FROM StudentInEducation AS SE
INNER JOIN Students AS S
ON SE.StudentId=S.ID
INNER JOIN Educations AS E
ON SE.EducationId=E.ID


-- View de sanal bir tablo olduðu için tablo select iþlemi ile gösterilir.
-- SELECT * FROM GetStudentByEducation