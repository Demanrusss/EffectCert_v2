ALTER TABLE Products
ADD CONSTRAINT FK_ProductsContractorLegals_ManufacturerId FOREIGN KEY (ManufacturerId)
	REFERENCES ContractorLegals(Id)
;

ALTER TABLE ProductQuantities
ADD CONSTRAINT FK_ProductQuantitiesProducts_ProductId FOREIGN KEY (ProductId)
	REFERENCES Products(Id),
ADD CONSTRAINT FK_ProductQuantitiesMeasurementUnits_MeasurementUnitId FOREIGN KEY (MeasurementUnitId)
	REFERENCES MeasurementUnits(Id)
;

ALTER TABLE SelectedSampleQuantities
ADD CONSTRAINT FK_SelectedSampleQuantitiesProductQuantities_ProductQuantityId FOREIGN KEY (ProductQuantityId)
	REFERENCES ProductQuantities(Id),
ADD CONSTRAINT FK_SelectedSampleQuantitiesMeasurementUnits_MeasurementUnitId FOREIGN KEY (MeasurementUnitId)
	REFERENCES MeasurementUnits(Id)
;