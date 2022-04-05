/********************************************************************************
MARKS AS DELETED ALL BOOKING RELATED ENTITIES (SCHEDULES, SCHEDULE AVAILABILITIES, SLOTS, APPOINTMENTS, SCHEDULEROLEAPPOINTMENTS)
/*******************************************************************************/

--SELECT Id, Name, CreationTime, Frwk_Discriminator FROM Core_Organisations
UPDATE Core_Organisations SET IsDeleted = 1
     WHERE Id NOT IN ('60850fdf-1f60-4441-8eb2-1942d8236370', '42882d0e-da7a-4934-ac74-1e32f572ad5a', '8a65f5c8-930d-4864-8913-1ac81d50851d', '0cdad6b0-a3b2-4cf6-9b7d-238d753f0657', '3e734e4d-45e9-4699-a053-2f000662bcbd', '4a5551fd-1209-49d6-9a69-5fcc816b48a6','535f2055-0bd5-4e7e-97b0-73cadd3f4617','26fccfa6-9e1c-4f7f-87aa-acdcaa4f96bb','00a9d6cb-da9d-4275-a5d3-becfeb3c6e04','c0b5b8a2-b1cc-428c-9b87-cd83e9c1fd47','c72def2a-0102-4b85-bef9-cee9d0917e15','eb507219-ae56-4a05-9e64-75cdc74cf774','4f95f9eb-75ba-4123-9578-98b6c57cd49c')

--SELECT * FROM Fhir_Schedules 
UPDATE Fhir_Schedules SET IsDeleted = 1
    WHERE HealthFacilityOwnerId NOT IN (SELECT Id FROM Core_Organisations WHERE IsDeleted = 1)

--SELECT * FROM Fhir_ScheduleAvailabilities
UPDATE Fhir_ScheduleAvailabilities SET IsDeleted = 1
 WHERE ScheduleId IN (SELECT Id FROM Fhir_Schedules WHERE IsDeleted = 1)

--SELECT * FROM Fhir_Slots
UPDATE Fhir_Slots SET IsDeleted = 1
 WHERE ScheduleId IN (SELECT Id FROM Fhir_Schedules WHERE IsDeleted = 1)

--SELECT * FROM Fhir_Appointments
UPDATE Fhir_Appointments SET IsDeleted = 1
 WHERE SlotId IN (SELECT Id FROM Fhir_Slots WHERE IsDeleted = 1)

--SELECT * FROM Core_ShaRoleAppointments
UPDATE Core_ShaRoleAppointments SET IsDeleted = 1
 WHERE Fhir_ScheduleId IN (SELECT Id FROM Fhir_Schedules WHERE IsDeleted = 1)
