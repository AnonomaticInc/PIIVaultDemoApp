# PIIVaultDemoApp

A sample C# application to show how to use the PII Vault

This application initially provides an example on how to connect to the PII Vault, obtain a security token, package PII into a Profile class, send that class to the vault and obtain a Poly-Anonymous Id (Poly-Id) in return.

These capabilities are imbedded in an application which allow:
1.	The user to select a CSV data file
2.	Create a schema to describe the data file
3.	Package the PII in the file into a Profile class which is then sent to the PII Vault.
4.	Retrieve the Poly-Id and anonymize the non-PII data

There are three menu buttons on the top. Use these to facilitate these steps.
1.	Select and load a CSV file
2.	Build a schema.
3.	Anonymize data. This step will take the input data, and the schema, and create an anonymized outfile data file.

On the Schema page, there are three settings which may be set for each column. The first is the Column Type. With this, the user can identify which columns in the schema are PII and if so, what type of PII they are. Blanks are the same as Non-PII. Next is Grouping. The purpose of this column is to link different elements of the same class. For instance, if there are two addresses in the data, then two columns may be specified as City, State or Zip. The Grouping value aligns the appropriate columns. Finally, the Redact column is used to specify which columns in the schema will be removed from the output data. This is because some data which is PII, such City and State, may still be desired to pass through for analytics.

To use this application active credentials to a working PII Vault is required. If needed, you can sign up for a free-trial online.
