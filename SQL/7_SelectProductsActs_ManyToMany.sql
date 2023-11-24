IF OBJECT_ID(N'SelectProductsActsSelectedSampleQuantities', N'U') IS NULL
BEGIN

CREATE TABLE SelectProductsActsSelectedSampleQuantities
(
    [SelectProductsActId] INT NOT NULL,
	[SelectedSampleQuantityId] INT NOT NULL,
    CONSTRAINT PK_SelectProductsActsSelectedSampleQuantities PRIMARY KEY (SelectProductsActId, SelectedSampleQuantityId),
    CONSTRAINT FK_SelectProductsActsSelectedSampleQuantities_SelectProductsActId FOREIGN KEY (SelectProductsActId)
		REFERENCES SelectProductsActs(Id),
	CONSTRAINT FK_SelectProductsActsSelectedSampleQuantities_SelectedSampleQuantityId FOREIGN KEY (SelectedSampleQuantityId)
		REFERENCES SelectedSampleQuantities(Id)
)

END