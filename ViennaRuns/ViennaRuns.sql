CREATE TABLE RunningGroup
(
    rg_name VARCHAR(255) NOT NULL,
    rg_id INT PRIMARY KEY NOT NULL
);
CREATE TABLE Weather
(
    w_date DATE PRIMARY KEY NOT NULL,
    w_weather VARCHAR(255) NOT NULL,
    w_temperature DECIMAL(18) NOT NULL
);
CREATE TABLE FeelingAfterRun
(
    far_id INT PRIMARY KEY NOT NULL,
    far_datfeel VARCHAR(255) NOT NULL
);
CREATE TABLE [User] (
  u_username VARCHAR(255) PRIMARY KEY NOT NULL,
  u_password VARCHAR(255),
  u_email VARCHAR(255),
  u_runninggroup INT,
  u_weight DECIMAL(18),
  FOREIGN KEY (u_runninggroup) REFERENCES RunningGroup (rg_id),
  FOREIGN KEY (u_runninggroup) REFERENCES RunningGroup (rg_id)
);
CREATE TABLE Run
(
    r_id INT PRIMARY KEY NOT NULL IDENTITY,
    r_user VARCHAR(255) NOT NULL,
    r_distance DECIMAL(18) NOT NULL,
    r_duration INT NOT NULL,
    r_date DATETIME NOT NULL,
    r_datfeel INT NOT NULL,
    CONSTRAINT FK__Run__r_user__4BAC3F29 FOREIGN KEY (r_user) REFERENCES [User] (u_username),
    CONSTRAINT FK__Run__r_datfeel__4CA06362 FOREIGN KEY (r_datfeel) REFERENCES FeelingAfterRun (far_id)
);