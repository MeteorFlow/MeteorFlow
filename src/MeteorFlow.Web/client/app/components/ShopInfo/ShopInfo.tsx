import "./ShopInfo.css";
import shopLogo from "../../../assets/shoplogo.png";
import { Flex } from "antd";
import { FacebookFilled, FacebookOutlined, InstagramOutlined, TwitterOutlined } from "@ant-design/icons";

const ShopDetails = {
    shopId: "1",
    logo: shopLogo,
    name: " Grocery Shop",
    description: "The grocery shop is the best shop around the city. This is being run under the store owner and our aim is to provide fresh and quality product and hassle free customer service.",
    adress: "1986 Spinnaker Lane, Illinois, Freeport, 61032, USA",
    phone: "5619327220",
    website: "https://redq.io",
}

export const ShopInfo: React.FC<{shopId: string}> = ({shopId}) => {
    return (
        <Flex className="ShopInfo" vertical>
            <Flex className="ShopInfo--description" vertical gap="middle" align="center">
                <img src={ShopDetails.logo} alt="logo" style={{width: '65%', borderRadius: '10px'}}/>
                <span style={{fontWeight: 'bolder', fontSize: '20px'}}>{ShopDetails.name}</span>
                <span style={{textAlign:'center', opacity: '0.8'}}>{ShopDetails.description}</span>
                <Flex justify="center" gap="small" style={{opacity: '0.8'}}>
                    <FacebookFilled />
                    <InstagramOutlined />
                    <TwitterOutlined />
                </Flex>
            </Flex>
            <Flex className="ShopInfo--details" vertical justify="center" gap="large">
                <Flex vertical gap="small">
                    <span style={{fontWeight: 'bold'}}>Address</span>
                    <span style={{opacity: '0.8'}}>{ShopDetails.adress}</span>
                </Flex>
                <Flex vertical gap="small">
                    <span style={{fontWeight: 'bold'}}>Phone</span>
                    <span style={{opacity: '0.8'}}>{ShopDetails.phone}</span>
                </Flex>
                <Flex vertical gap="small">
                    <span style={{fontWeight: 'bold'}}>Website</span>
                    <Flex justify="space-between">
                        <span style={{opacity: '0.8'}}>{ShopDetails.website}</span>
                        <a href={ShopDetails.website} style={{fontWeight: 'bolder', color:'#009f7f'}}>Visit this site</a>
                    </Flex>
                </Flex>
            </Flex>
        </Flex>
    )
}