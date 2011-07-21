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
		<xsl:value-of select="$package" />
		<xsl:for-each select="table[@name=$tablename]">

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dbros.Software.VIP.Classes.Core;
using Dbros.Software.VIP.Classes.Modules.Member.DS;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections;
using System.Data.Common;

<xsl:variable name="ClassName"><xsl:call-template name="upperCase"><xsl:with-param name="textToTransform" select="@name" /></xsl:call-template></xsl:variable>

namespace Dbros.Software.VIP.Classes.Modules.[[[]]].DAL
{
	public class <xsl:value-of select="$ClassName" />DAL : BaseDAL
	{
		/// &lt;summary&gt;
		/// Get a <xsl:value-of select="@name"/> by your primary key
		/// &lt;/summary&gt;<xsl:for-each select="column[@primaryKey='true']">
		/// &lt;param name="<xsl:value-of select="@name"/>"&gt;<xsl:value-of select="@description"/>&lt;/param&gt;</xsl:for-each>
		public DS<xsl:value-of select="$ClassName" />.<xsl:value-of select="$ClassName" />Row FindByPk(<xsl:for-each select="column[@primaryKey='true']">
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
			DbCommand command = null;
			DS<xsl:value-of select="$ClassName" /> ds = new DS<xsl:value-of select="$ClassName" />();

			try
			{
				string query = "SELECT <xsl:for-each select="column"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/></xsl:for-each> ";
				query += "FROM <xsl:value-of select="@name" /> ";
				query += "WHERE <xsl:for-each select="column[@primaryKey='true']"><xsl:if test="position() != 1"> and </xsl:if><xsl:value-of select="@name"/> = @<xsl:value-of select="@name"/></xsl:for-each> ";
				command = dataBase.GetSqlStringCommand(query);
				<xsl:for-each select="column[@primaryKey='true']">
				AddParameter(command, "@<xsl:value-of select="@name"/>", <xsl:value-of select="@name"/>);</xsl:for-each>
			
				dataBase.LoadDataSet(command, ds, ds.<xsl:value-of select="$ClassName" />.TableName);
			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.DAL);
			}
			finally
			{
				if (command != null) command.Dispose();
			}

			if (ds.<xsl:value-of select="$ClassName" />.Rows.Count > 0)
			{
				return ds.<xsl:value-of select="$ClassName" />[0];
			}
			else
			{
				return null;
			}
		}

		/// &lt;summary&gt;
		/// Find <xsl:value-of select="@name"/> by generic filter. Internal Use Only
		/// &lt;/summary&gt;
		/// &lt;param name="row"&gt;DS<xsl:value-of select="$ClassName" />.<xsl:value-of select="$ClassName" />Row&lt;/param&gt;
		protected DS<xsl:value-of select="$ClassName" />Row.<xsl:value-of select="$ClassName" />DataTable FindByFilter(DS<xsl:value-of select="$ClassName" />.<xsl:value-of select="$ClassName" />Row row)
		{
			DbCommand command = null;
			DS<xsl:value-of select="$ClassName" /> ds = new DS<xsl:value-of select="$ClassName" />();

			try
			{
				string query = "SELECT <xsl:for-each select="column"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/></xsl:for-each> ";
				query += "FROM <xsl:value-of select="@name" /> ";
				query += "WHERE 1=1 ";
				
				command = dataBase.GetSqlStringCommand(query);
				<xsl:for-each select="column">
				if (!row.Is<xsl:value-of select="@name"/>Null())
				{
					query += " AND <xsl:value-of select="@name"/> = @<xsl:value-of select="@name"/> ";
					AddParameter(command, "@<xsl:value-of select="@name"/>", row.<xsl:value-of select="@name"/>);
				}
				</xsl:for-each>

				command.CommandText = query;
				dataBase.LoadDataSet(command, ds, ds.<xsl:value-of select="@name"/>.TableName);
			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.DAL);
			}
			finally
			{
				if (command != null) command.Dispose();
			}

			return ds.<xsl:value-of select="@name"/>;
		}


		public int Insert(DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			DbCommand command = null;
			int numChanges = 0;

			try
			{
				string query = "INSERT INTO <xsl:value-of select="@name"/> ";
				query += " (<xsl:for-each select="column"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/></xsl:for-each>) ";
				query += " values ";
				query += " (<xsl:for-each select="column"><xsl:if test="position() != 1">, </xsl:if>@<xsl:value-of select="@name"/></xsl:for-each>) ";

				command = dataBase.GetSqlStringCommand(query);
				<xsl:for-each select="column">AddParameter(command, "@<xsl:value-of select="@name"/>", row.<xsl:value-of select="@name"/>);
				</xsl:for-each>
				numChanges = dataBase.ExecuteNonQuery(command);

			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.DAL);
			}
			finally
			{
				if (command != null) command.Dispose();
			}

			return numChanges;
		}

		public int Update(DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			DbCommand command = null;
			int numChanges = 0;

			try
			{
				string query = " UPDATE <xsl:value-of select="@name"/> SET ";
				query += " <xsl:for-each select="column[not(@primaryKey='PrKey')]"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/> = @<xsl:value-of select="@name"/></xsl:for-each> ";
				query += " WHERE <xsl:for-each select="column[@primaryKey='true']"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/> = @<xsl:value-of select="@name"/></xsl:for-each> ";

				command = dataBase.GetSqlStringCommand(query);
				<xsl:for-each select="column">AddParameter(command, "@<xsl:value-of select="@name"/>", row.<xsl:value-of select="@name"/>);
				</xsl:for-each>
				numChanges = dataBase.ExecuteNonQuery(command);

			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.DAL);
			}
			finally
			{
				if (command != null) command.Dispose();
			}

			return numChanges;
		}

		public int Delete(DS<xsl:value-of select="$ClassName"/>.<xsl:value-of select="$ClassName"/>Row row)
		{
			DbCommand command = null;
			int numChanges = 0;

			try
			{
				string query = " DELETE <xsl:value-of select="@name"/> ";
				query += "WHERE <xsl:for-each select="column[@primaryKey='true']"><xsl:if test="position() != 1">, </xsl:if><xsl:value-of select="@name"/> = @<xsl:value-of select="@name"/></xsl:for-each> ";

				command = dataBase.GetSqlStringCommand(query);
				<xsl:for-each select="column[@primaryKey='true']">AddParameter(command, "@<xsl:value-of select="@name"/>", row.<xsl:value-of select="@name"/>);
				</xsl:for-each>
				numChanges = dataBase.ExecuteNonQuery(command);

			}
			catch (Exception ex)
			{
				ExceptionManager.Handle(ex, ExceptionPolicies.DAL);
			}
			finally
			{
				if (command != null) command.Dispose();
			}

			return numChanges;
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
