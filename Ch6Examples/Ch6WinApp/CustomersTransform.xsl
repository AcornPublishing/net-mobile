<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<CustomerList>
		<xsl:for-each select="//Customers">
			<Customer>
				<ID><xsl:value-of select="CustomerID"/></ID>
			</Customer>
		</xsl:for-each>	  
		</CustomerList>
	</xsl:template>
</xsl:stylesheet>