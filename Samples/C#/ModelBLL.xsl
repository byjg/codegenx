<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY lower "abcdefghijklmnopqrstuvwxyz">
	<!ENTITY upper "ABCDEFGHIJKLMNOPQRSTUVWXYZ">
]>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:param name="tablename"></xsl:param>


	<xsl:output method="text"/>

	<xsl:template match="database">
		<xsl:for-each select="table[@name=$tablename]">

<xsl:variable name="ClassName"><xsl:call-template name="upperCase"><xsl:with-param name="textToTransform" select="@name" /></xsl:call-template></xsl:variable>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dbros.Software.VIP.Classes.Modules.Member.DS;
using Dbros.Software.VIP.Classes.Modules.Member.DAL;
using Dbros.Software.VIP.Classes.Core;

namespace Dbros.Software.VIP.Classes.Modules.[[[]]].BLL
{

	///&lt;summary&gt;
	/* <xsl:value-of select="@description" />
	*/
	///&lt;/summary&gt;
	public class <xsl:value-of select="$ClassName"/>BLL : BaseBLL&lt;<xsl:value-of select="$ClassName"/>DAL&gt;
	{

		/// &lt;summary&gt;
		/// Insert a new row
		/// &lt;/summary&gt;
		public int Insert(DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			int changes = 0;

			try
			{
				Validate(DbAction.Insert, row);
				changes = InstanceDAL.Insert(row);
			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.BLL);
			}

			return changes;
		}

		/// &lt;summary&gt;
		/// Update a row
		/// &lt;/summary&gt;
		public int Update(DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			int changes = 0;

			try
			{
				Validate(DbAction.Update, row);
				changes = InstanceDAL.Update(row);
			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.BLL);
			}

			return changes;
		}

		/// &lt;summary&gt;
		/// Delete a row in database
		/// &lt;/summary&gt;
		public int Delete(DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			int changes = 0;

			try
			{
				Validate(DbAction.Delete, row);
				changes = InstanceDAL.Delete(row);
			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.BLL);
			}

			return changes;
		}

		/// &lt;summary&gt;
		/// Find by Primary Key
		/// &lt;/summary&gt;<xsl:for-each select="column[@primaryKey='true']">
		/// &lt;param name="<xsl:value-of select="@name" />"&gt;<xsl:value-of select="@description" />&lt;/param&gt;</xsl:for-each>
		public DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row FindByPk(<xsl:for-each select="column[@primaryKey='true']">
			<xsl:if test="position()!=1">, </xsl:if>
			<xsl:call-template name="convert_data_type">
				<xsl:with-param name="sqltype">
					<xsl:value-of select="@type"/>
				</xsl:with-param>
			</xsl:call-template>
			<xsl:text> </xsl:text>
			<xsl:value-of select="@name"/>
		</xsl:for-each>)
		{
			try
			{
				return InstanceDAL.FindByPk(<xsl:for-each select="column[@primaryKey='true']"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/></xsl:for-each>);
			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.BLL);
			}

			return null; 
		}  

		protected void Validate(DbAction action, DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			if (row == null)
				throw new VIPArgumentNullException("<xsl:value-of select="$ClassName"/>Row");

			if (action == DbAction.Insert || action == DbAction.Update)
			{
				<xsl:for-each select="column[@required='true']">
				if(row.Is<xsl:value-of select="@name"/>Null())
					throw new VIPArgumentNullException("<xsl:value-of select="@name"/>");
				</xsl:for-each>
				<xsl:for-each select="column[contains(@type, 'char')]">
				if(!row.Is<xsl:value-of select="@name"/>Null() &amp;&amp; row.<xsl:value-of select="@name"/>.Length &gt; <xsl:value-of select="@size" />)
					throw new VIPArgumentLengthException("<xsl:value-of select="@name"/>");
				</xsl:for-each>
			}

			if (action == DbAction.Delete || action == DbAction.Update)
			{
				<xsl:for-each select="column[@primaryKey='true']">
				if(row.Is<xsl:value-of select="@name"/>Null())
					throw new VIPArgumentNullException("<xsl:value-of select="@name"/>");
				</xsl:for-each>
			}
		}
	}
}


		</xsl:for-each>
	</xsl:template>

	
	
	
	
	
	
	
	
	
	
	
	
	<!--
	Functions
	-->
	<xsl:template name="convert_data_type">
		<xsl:param name="sqltype"/>
		<xsl:choose>
			<xsl:when test="contains($sqltype, 'nvarchar')">string</xsl:when>
			<xsl:when test="contains($sqltype, 'char')">string</xsl:when>
			<xsl:when test="contains($sqltype, 'datetime')">DateTime</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$sqltype"/>
			</xsl:otherwise>
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
