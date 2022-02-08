-- ilk ekleme i�leminde StudentAttence tablosunda bulunan
-- Score ve IsSuccess sut�nlar�n varsay�lan de�eri s�ras�lar 0 ve 0 d�r.
-- O y�zden after insert i�lemini gerekli bulmad�m
-- Her update i�leminden sonra Score ce IsSuccess de�eri de�i�mektedir.
-- Score i�in Education tablosundaki ��rencinin kay�t oldu�u e�itimin toplam haftas� ile 
-- toplam girdi�i dersin y�zdesi hesaplanarak elde edilir.
-- IsSuccess ise Score de�eri %80 ve �zeriyse True(1) olarak de�i�tirilir.

CREATE TRIGGER UpdateStudentScore
   ON  StudentAttence
   AFTER UPDATE
AS 
BEGIN
	-- inserted tablosundan al�nan de�i�kenler
	DECLARE @studentID int, @weeksAttence int,@score float
	-- ak��ta kullan�lan de�i�kenler
	DECLARE @scorePercent float, @isSuccess bit, @totalWeek int
	-- de�i�kenleri inserted tablosundan ilgili de�erlere atand�
	SELECT @studentID=StudentID, @weeksAttence=WeeksAttended,
		   @score = Score
	FROM inserted
	-- totalWeek de�eri Education tablosundan al�nd�. Y�zde i�leminde kullan�lacak
	SELECT @totalWeek=TotalWeek FROM Educations
	-- y�zde hesab� yap�ld�
	SET @scorePercent = (@weeksAttence*100/@totalWeek)
	-- @scorePercent %80 ve �zeriyse ge�er de�ilse kal�r
	IF (@scorePercent>=80)
		BEGIN
			SET @isSuccess=1
		END
	ELSE
		BEGIN
			SET @isSuccess=0
		END

	-- Update i�lemi yap�l�r
	UPDATE StudentAttence 
	SET Score = @scorePercent, IsSucces=@isSuccess
	WHERE StudentID = @studentID

ENDc