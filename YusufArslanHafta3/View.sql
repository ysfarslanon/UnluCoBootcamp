CREATE VIEW GetStudentByEducation AS
SELECT E.Name AS E�itim, S.FirstName AS Ad, S.LastName AS Soyad
FROM StudentInEducation AS SE
INNER JOIN Students AS S
ON SE.StudentId=S.ID
INNER JOIN Educations AS E
ON SE.EducationId=E.ID


-- View de sanal bir tablo oldu�u i�in tablo select i�lemi ile g�sterilir.
-- SELECT * FROM GetStudentByEducation