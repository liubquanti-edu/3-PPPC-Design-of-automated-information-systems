DROP TABLE avto;
DROP TABLE photo;
DROP TABLE user_data;

CREATE TABLE avto (id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER REFERENCES user_data (id), brand STRING, model STRING, description TEXT, price STRING);
CREATE TABLE user_data (id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, name STRING, surname STRING, phone STRING, tag STRING);
CREATE TABLE photo (user_id INTEGER, ad_id INTEGER, picture BLOB);


--SELECT * FROM user_data;

-- SELECT * FROM avto;