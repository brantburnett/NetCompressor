<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:w="http://schemas.microsoft.com/wix/2006/wi">
  
  <xsl:output method="xml" version="1.0" encoding="utf-8" />

  <xsl:template match="@* | *">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="/">
    <xsl:processing-instruction name="include">Definitions.wxi</xsl:processing-instruction>
    <xsl:apply-templates />
  </xsl:template>
  
  <xsl:template match="/w:Wix" >
    <w:Wix>
      <xsl:apply-templates select="w:Fragment" />
    </w:Wix>
  </xsl:template>

  <xsl:template match="w:Fragment" >
    <w:Fragment>
      <xsl:apply-templates />
    </w:Fragment>
  </xsl:template>

  <xsl:template match="w:Directory">
    <xsl:copy />
  </xsl:template>

  <xsl:template match="w:ComponentGroup">
    <xsl:copy />
  </xsl:template>

  <xsl:template match="w:DirectoryRef">
    <w:DirectoryRef Id="INSTALLLOCATION">
      <xsl:apply-templates />
    </w:DirectoryRef>
  </xsl:template>
  
</xsl:stylesheet>