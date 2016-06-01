CREATE TABLE [User]
(
    u_username TEXT PRIMARY KEY,
    u_password TEXT,
    u_email TEXT,
    u_runninggroup INTEGER,
    u_weight DECIMAL,
    CONSTRAINT [User_[RunningGroup]]_rg_id_fk] FOREIGN KEY (u_runninggroup) REFERENCES ViennaRuns.[RunningGroup] (rg_id)
)
GO
CREATE TABLE [RunningGroup] (
	rg_name text NOT NULL,
	rg_id integer NOT NULL,
  CONSTRAINT [PK_RUNNINGGROUP] PRIMARY KEY CLUSTERED
  (
  [rg_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)

GO
CREATE TABLE [Weather] (
	w_date date NOT NULL,
	w_weather text NOT NULL,
	w_temperature decimal NOT NULL,
  CONSTRAINT [PK_WEATHER] PRIMARY KEY CLUSTERED
  (
  [w_date] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Run] (
	r_id integer NOT NULL,
	r_user text NOT NULL,
	r_distance decimal NOT NULL,
	r_duration integer NOT NULL,
	r_date date NOT NULL,
	r_datfeel integer NOT NULL,
  CONSTRAINT [PK_RUN] PRIMARY KEY CLUSTERED
  (
  [r_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [FeelingAfterRun] (
	far_id integer NOT NULL,
	far_datfeel text NOT NULL,
  CONSTRAINT [PK_FEELINGAFTERRUN] PRIMARY KEY CLUSTERED
  (
  [far_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [User] WITH CHECK ADD CONSTRAINT [User_fk0] FOREIGN KEY ([runninggroup]) REFERENCES [RunningGroup]([rg_id])
ON UPDATE CASCADE
GO
ALTER TABLE [User] CHECK CONSTRAINT [User_fk0]
GO



ALTER TABLE [Run] WITH CHECK ADD CONSTRAINT [Run_fk0] FOREIGN KEY ([r_user]) REFERENCES [User]([u_username])
ON UPDATE CASCADE
GO
ALTER TABLE [Run] CHECK CONSTRAINT [Run_fk0]
GO
ALTER TABLE [Run] WITH CHECK ADD CONSTRAINT [Run_fk1] FOREIGN KEY ([r_datfeel]) REFERENCES [FeelingAfterRun]([far_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Run] CHECK CONSTRAINT [Run_fk1]
GO


