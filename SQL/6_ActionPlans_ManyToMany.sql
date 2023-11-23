IF OBJECT_ID(N'ActionPlansLaboratories', N'U') IS NULL
BEGIN

CREATE TABLE ActionPlansLaboratories
(
    [ActionPlanId] INT NOT NULL,
	[LaboratoryId] INT NOT NULL,
    CONSTRAINT PK_ActionPlansLaboratories PRIMARY KEY (ActionPlanId, LaboratoryId),
    CONSTRAINT FK_ActionPlansLaboratories_ActionPlanId FOREIGN KEY (ActionPlanId)
		REFERENCES ActionPlans(Id),
	CONSTRAINT FK_ActionPlansLaboratories_LaboratoryId FOREIGN KEY (LaboratoryId)
		REFERENCES Laboratories(Id)
)

END