<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY lower "abcdefghijklmnopqrstuvwxyz">
	<!ENTITY upper "ABCDEFGHIJKLMNOPQRSTUVWXYZ">
]>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:param name="tablename"></xsl:param>
	<xsl:param name="datacontext"></xsl:param>
    <xsl:param name="datacontext_using"></xsl:param>
    <xsl:output method="text"/>
	<xsl:template match="database">
		<xsl:for-each select="table[@name=$tablename]">
			<xsl:variable name="ClassName">
				<xsl:call-template name="upperCase">
					<xsl:with-param name="textToTransform" select="@name" />
				</xsl:call-template>
			</xsl:variable>
			<xsl:variable name="DataContextName">
				<xsl:call-template name="upperCase">
					<xsl:with-param name="textToTransform" select="$datacontext" />
				</xsl:call-template>
			</xsl:variable>
//==============================================================================
//===   <xsl:value-of select="$tablename" />.cs
//=== 
//=== Essa classe é gerada automaticamente pelo CodeGenX. 
//==============================================================================

using System;
using System.Linq;
using System.Data.Linq.Mapping;
using <xsl:value-of select="$datacontext_using" />; 
//{@@@[//CustomInclude
//CustomInclude]}@@@

namespace PeixeUrbano.Payment.API.DB.Model
{

  [Table(Name="<xsl:value-of select="$tablename" />")]
  public class <xsl:value-of select="$ClassName" />
  {

	  #region Defining Storages
	  <xsl:for-each select="column">
	  private <xsl:call-template name="convert_data_type"><xsl:with-param name="sqltype"><xsl:value-of select="@type"/></xsl:with-param><xsl:with-param name="required"><xsl:value-of select="@required"/></xsl:with-param></xsl:call-template> _<xsl:value-of select="@name" />;
	  </xsl:for-each>
	  #endregion

	  #region Properties

	  <xsl:for-each select="column">
	  [Column(Storage="_<xsl:value-of select="@name" />", DbType="<xsl:if test="@size"><xsl:value-of select="@type" />(<xsl:value-of select="@size" />)</xsl:if><xsl:if test="not(@size)"><xsl:value-of select="@type" /></xsl:if><xsl:if test="@required"> NOT NULL</xsl:if>", CanBeNull=<xsl:if test="@required='true'">false</xsl:if><xsl:if test="not(@required='true')">true</xsl:if><xsl:if test="@primaryKey='true'">, IsPrimaryKey=true</xsl:if><xsl:if test="@autoIncrement='true'">, IsDbGenerated=true, AutoSync=AutoSync.OnInsert</xsl:if>)]<xsl:variable name="field"><xsl:call-template name="upperCase"><xsl:with-param name="textToTransform" select="@name" /></xsl:call-template></xsl:variable>
	  public <xsl:call-template name="convert_data_type"><xsl:with-param name="sqltype"><xsl:value-of select="@type"/></xsl:with-param><xsl:with-param name="required"><xsl:value-of select="@required"/></xsl:with-param></xsl:call-template> <xsl:text> </xsl:text> <xsl:value-of select="$field" />
	  {
		  get
		  {
			  return this._<xsl:value-of select="@name" />;
		  }
		  set
		  {
			  if ((this._<xsl:value-of select="@name" /> != value))
			  {
				  //this.OnPropertyChanging("<xsl:value-of select="$field" />");
				  this._<xsl:value-of select="@name" /> = value;
				  //this.OnPropertyChanged("<xsl:value-of select="$field" />");
			  }
		  }
	  }
	  </xsl:for-each>
			
	  #endregion


      #region Database Functions
      /// &lt;summary&gt;
      /// Get a <xsl:value-of select="$ClassName" /> by Primary Key
      /// &lt;/summary&gt;
	  public static <xsl:value-of select="$ClassName" /> GetByPK(<xsl:for-each select="column[@primaryKey='true']"><xsl:if test="position()!=1">, </xsl:if><xsl:call-template name="convert_data_type"><xsl:with-param name="sqltype"><xsl:value-of select="@type"/></xsl:with-param><xsl:with-param name="required"><xsl:value-of select="@required"/></xsl:with-param></xsl:call-template><xsl:text> </xsl:text><xsl:value-of select="@name"/></xsl:for-each>)
	  {
          using (<xsl:value-of select="$datacontext" /> context = new <xsl:value-of select="$datacontext" />())
		  {
			  return (from s in context.<xsl:value-of select="$ClassName" />Collection
						    where (<xsl:for-each select="column[@primaryKey='true']"><xsl:if test="position()!=1"> &amp;&amp; </xsl:if>(s.<xsl:call-template name="upperCase"><xsl:with-param name="textToTransform" select="@name" /></xsl:call-template> == <xsl:value-of select="@name"/>)</xsl:for-each>)
						    select s).SingleOrDefault();
		  }
      }
      #endregion


	  #region Custom Code

	  //{@@@[//CustomValues
	  //CustomValues]}@@@
	
	  #endregion

  }
}
		</xsl:for-each>
	</xsl:template>

	
	
	
	
	
	
	
	
	
	
	
	
	<!--
	Functions
	-->
	<xsl:template name="convert_data_type">
		<xsl:param name="sqltype"/>
		<xsl:param name="required"/>
		<xsl:variable name="sqltype2" select="translate($sqltype, '&upper;', '&lower;')" />
		<xsl:choose>
			<xsl:when test="contains($sqltype2, 'nvarchar')">string</xsl:when>
			<xsl:when test="contains($sqltype2, 'char')">string</xsl:when>
			<xsl:when test="contains($sqltype2, 'bit')">bool<xsl:if test="not($required='true')">?</xsl:if></xsl:when>
			<xsl:when test="contains($sqltype2, 'int')">int<xsl:if test="not($required='true')">?</xsl:if></xsl:when>
			<xsl:when test="contains($sqltype2, 'datetime')">DateTime<xsl:if test="not($required='true')">?</xsl:if></xsl:when>
			<xsl:when test="contains($sqltype2, 'timestamp')">DateTime<xsl:if test="not($required='true')">?</xsl:if></xsl:when>
			<xsl:when test="contains($sqltype2, 'decimal')">decimal<xsl:if test="not($required='true')">?</xsl:if></xsl:when>
			<xsl:when test="contains($sqltype2, 'xml')">System.Xml.XmlDocument</xsl:when>
			<xsl:when test="contains($sqltype2, 'binary')">System.IO.MemoryStream</xsl:when>
			<xsl:otherwise> <xsl:value-of select="$sqltype"/>? </xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="convert_data_type2">
		<xsl:param name="sqltype"/>
		<xsl:choose>
			<xsl:when test="contains($sqltype, 'nvarchar')">string</xsl:when>
			<xsl:when test="contains($sqltype, 'char')">string</xsl:when>
			<xsl:when test="contains($sqltype, 'datetime')">DateTime</xsl:when>
			<xsl:when test="contains($sqltype, 'decimal')">Decimal</xsl:when>
			<xsl:when test="contains($sqltype, 'xml')">string</xsl:when>
			<xsl:when test="contains($sqltype, 'binary')">System.IO.MemoryStream</xsl:when>
			<xsl:otherwise><xsl:value-of select="$sqltype"/></xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template name="upperCase">
		<xsl:param name="textToTransform" />
		<xsl:variable name="head">
			<xsl:choose>
				<xsl:when test="contains($textToTransform, '_')">
					<xsl:value-of select="substring-before($textToTransform, '_')" />
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$textToTransform" />
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:variable name="tail" select="substring-after($textToTransform, '_')" />
		<xsl:variable name="firstTransform"	select="concat(translate(substring($head, 1, 1),'&lower;', '&upper;'),substring($head, 2))" />
		<xsl:choose>
			<xsl:when test="$tail">
				<xsl:value-of select="$firstTransform" />
				<xsl:call-template name="upperCase">
					<xsl:with-param name="textToTransform" select="$tail" />
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$firstTransform" />
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	
</xsl:stylesheet>
