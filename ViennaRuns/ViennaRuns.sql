CREATE TABLE [RunningGroup] (
	rg_name varchar(255) NOT NULL,
	rg_id integer NOT NULL,
  CONSTRAINT [PK_RUNNINGGROUP] PRIMARY KEY CLUSTERED
  (
  [rg_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)

GO
CREATE TABLE [Weather] (
	w_date date NOT NULL,
	w_weather varchar(255) NOT NULL,
	w_temperature decimal NOT NULL,
  CONSTRAINT [PK_WEATHER] PRIMARY KEY CLUSTERED
  (
  [w_date] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Run] (
	r_id integer NOT NULL,
	r_user varchar(255) NOT NULL,
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
	far_datfeel varchar(255) NOT NULL,
  CONSTRAINT [PK_FEELINGAFTERRUN] PRIMARY KEY CLUSTERED
  (
  [far_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User]
(
    u_username varchar(255) PRIMARY KEY NOT NULL,
    u_password varchar(255),
    u_email varchar(255),
    u_runninggroup INTEGER,
    u_weight DECIMAL,
    CONSTRAINT [User_[RunningGroup]]_rg_id_fk] FOREIGN KEY (u_runninggroup) REFERENCES [RunningGroup] (rg_id)
)

GO
ALTER TABLE [User] WITH CHECK ADD CONSTRAINT [User_fk0] FOREIGN KEY ([u_runninggroup]) REFERENCES [RunningGroup]([rg_id])
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


