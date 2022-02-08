-- ilk ekleme iþleminde StudentAttence tablosunda bulunan
-- Score ve IsSuccess sutünlarýn varsayýlan deðeri sýrasýlar 0 ve 0 dýr.
-- O yüzden after insert iþlemini gerekli bulmadým
-- Her update iþleminden sonra Score ce IsSuccess deðeri deðiþmektedir.
-- Score için Education tablosundaki öðrencinin kayýt olduðu eðitimin toplam haftasý ile 
-- toplam girdiði dersin yüzdesi hesaplanarak elde edilir.
-- IsSuccess ise Score deðeri %80 ve üzeriyse True(1) olarak deðiþtirilir.

CREATE TRIGGER UpdateStudentScore
   ON  StudentAttence
   AFTER UPDATE
AS 
BEGIN
	-- inserted tablosundan alýnan deðiþkenler
	DECLARE @studentID int, @weeksAttence int,@score float
	-- akýþta kullanýlan deðiþkenler
	DECLARE @scorePercent float, @isSuccess bit, @totalWeek int
	-- deðiþkenleri inserted tablosundan ilgili deðerlere atandý
	SELECT @studentID=StudentID, @weeksAttence=WeeksAttended,
		   @score = Score
	FROM inserted
	-- totalWeek deðeri Education tablosundan alýndý. Yüzde iþleminde kullanýlacak
	SELECT @totalWeek=TotalWeek FROM Educations
	-- yüzde hesabý yapýldý
	SET @scorePercent = (@weeksAttence*100/@totalWeek)
	-- @scorePercent %80 ve üzeriyse geçer deðilse kalýr
	IF (@scorePercent>=80)
		BEGIN
			SET @isSuccess=1
		END
	ELSE
		BEGIN
			SET @isSuccess=0
		END

	-- Update iþlemi yapýlýr
	UPDATE StudentAttence 
	SET Score = @scorePercent, IsSucces=@isSuccess
	WHERE StudentID = @studentID

ENDc