CodeGenX
========

Code generator highly flexible and extensible based on Torque XML and XSL transformations

## Introducing to CodeGenX

CodeGenX is a Code generator highly flexible and extensible based on Torque XML and XSL transformations. You virtually can generate code targeted to any programming language just using your own XSL template.

## Some CodeGenX features

* Generate a single file from each table in Torque XML
* Custom code added by user are not replaced when the CodeGenX generate the file again
* Custom parameters for each table
* Save a project for you codegen
* Very fast!
* Lightweight
* Run in Windows (.NET) or Linux (Mono)

## Generate code with CodeGenX

The first step is create a Torque XML. You can create your own XML file or you can use a tool to do this for you. We recommend Druid. Druid from Sourceforge is a database modeling tool and it have some specific features like generate a documentation from your database and export to Torque XML file. But if you know any other tool, let me know. The Torque XML will be like this:

````XML
<?xml version="1.0" encoding="UTF-8"?>

<database name="mydatabase">
  <table name="mytable">
		<column name="id" primaryKey="true" required="true" type="int"/>
		<column name="title" required="true" type="varchar" size="30"/>
	</table>
</database>
````

After that, you have to create a XSL file. We know XSL is not a user friendly language, but it is powerful to transform a XML in any other thing you want. To make the things easier we recommend you create a XSL using the model below:

````XSLT
<?xml version="1.0" encoding="utf-8"?>

<!DOCTYPE xsl:stylesheet [
	<!ENTITY lower "abcdefghijklmnopqrstuvwxyz">
	<!ENTITY upper "ABCDEFGHIJKLMNOPQRSTUVWXYZ">
]>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

	<xsl:param name="tablename"></xsl:param>
	<xsl:param name="package"></xsl:param>

	<xsl:output method="text"/>

	<xsl:template match="database">

		<xsl:for-each select="table[@name=$tablename]">

		<!-- START: PUT YOUR CODE HERE -->

		<!-- END: PUT YOUR CODE HERE -->

		</xsl:for-each>

	</xsl:template>

	<!-- PUT YOUR XSL FUNCTION HERE! -->

</xsl:stylesheet>
````


This is a suggestion. You can use any XSL you want.

Here you can see how you can handle the Torque XML file:

````XSLT
class <xsl:value-of select="$tablename">
{
	<xsl:for-each select="column">
	protected $_<xsl:value-of select="@name">;

	public get<xsl:value-of select="@name">()
	{
		return $this->_<xsl:value-of select="@name">;
	}
	public set<xsl:value-of select="@name">($value)
	{
		$this->_<xsl:value-of select="@name"> = $value;
	}
	</xsl:for-each>
}
````

and the result code will be:

````PHP
class mytable
{
	protected $_id;

	public getid()
	{
		return $this->_id;
	}
	public setid($value)
	{
		$this->_id = $value;
	}
	
	protected $_title;

	public gettitle()
	{
		return $this->_title;
	}
	public settitle($value)
	{
		$this->_title = $value;
	}
	
}
````
