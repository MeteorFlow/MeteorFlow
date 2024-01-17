import { Col, Flex, Row } from "antd";
import Navbar from "../../components/Navbar/Navbar";
import { ShopInfo } from "../../components/ShopInfo/ShopInfo";
import "./ShopProduct.css";
import shopBanner from "../../../assets/shopBanner.png";
import { ProductList } from "../../components/ProductList/ProductList";

export const ShopProduct: React.FC<{shopId?: string}> = ({shopId}) => {
    return(
        <div className="ShopProductPage">
            <Flex>
                <Flex  style={{flex: '3'}}>
                    <ShopInfo shopId={shopId ? shopId : '1'}/> 
                </Flex>
                <Flex className="ShopProduct" vertical gap="large" style={{flex: '10', padding: '24px 24px 0 0'}}>
                    <img src={shopBanner} alt="shop banner" className="ShopBanner" />
                    <ProductList shopId={shopId} />
                </Flex>
            </Flex>

        </div>
    )
}