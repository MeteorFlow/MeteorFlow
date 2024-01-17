import "./ProductDetail.css";
import "../../App.css";
import { ProductDescription } from "../../components/ProductDescription/ProductDescription";
import { Flex, Pagination, Select, Tag } from "antd";
import { ProductList } from "../../components/ProductList/ProductList";
import { NavLink } from "react-router-dom";
import { ArrowLeftOutlined, CheckCircleFilled, DislikeFilled, LikeFilled, StarFilled } from "@ant-design/icons";
import { Rating } from "../../components/Rating/Rating";
import { BsThreeDotsVertical } from "react-icons/bs";

type ProductPageProps = {
    productId?: string
}

const ItemDetail={
    productId: "1",
    title: "Apples",
    unit: "1lb",
    description: "An apple is a sweet, edible fruit produced by an apple tree (Malus domestica). Apple trees are ... The skin of ripe apples is generally red, yellow, green, pink, or russetted, though many bi- or tri-colored cultivars may be found.",
    price: "2.00",
    salePrice: "1.60",
    available: "18 pieces",
    categories: ["fruits & vegetables", "fruits"],
    seller: "Grocery Shop",
    rate: {rating: 4.67, ratingStar: [2, 1, 0, 0, 0], ratingNumber: 3},
    image: ["https://assets.woolworths.com.au/images/2010/155003.jpg?impolicy=wowcdxwbjbx&w=900&h=900", 
    "https://post.healthline.com/wp-content/uploads/2020/09/health-benefits-of-apples-732x549-thumbnail-732x549.jpg", 
    "https://5.imimg.com/data5/AK/RA/MY-68428614/apple-500x500.jpg",
     "https://minchinburyfruitmarket.com.au/content/images/thumbs/0000570_apple-red-delicious-lge_400.jpeg"]
}

const reviews = [
    {
        rating: 5,
        by: 'Customer1',
        comment: 'Apple is wonderful. Shop owner is really nice',
        date: 'March 18,2022',
        likes: '5',
        dislikes: '2',
    },
    {
        rating: 4,
        by: 'Customer2',
        comment: 'I really enjoy apple but wait long time for delivery',
        date: 'March 25,2022',
        likes: '4',
        dislikes: '0',
    }
]

export const ProductPage: React.FC<ProductPageProps> = ({productId}) => {
    const handleChange = (value: string) => {
        console.log(`selected ${value}`);
      };

    return(
        <div className="ProductPage">
            <div className="ProductDetail">
                <NavLink to="/home" className="BackHomeButton">
                    <ArrowLeftOutlined />
                    <span style={{paddingLeft: '8px'}}>Back</span>
                </NavLink>
                <ProductDescription productInfo={ItemDetail}/>
                <Flex className="ProductDetail--Rating" vertical gap="large">
                    <span style={{fontWeight: "bolder", fontSize: "20px"}}>Ratings & Reviews of {ItemDetail.title}</span>
                    <Rating rate={ItemDetail.rate} />
                </Flex> 
                <Flex className="ProductDetail--Review" vertical>
                    <Flex className='ProductDetail--Review__title' align='center'>
                        <Flex flex='3' style={{fontWeight: "bolder", fontSize: "20px" , paddingLeft: '20px'}}>Product Reviews ({reviews.length})</Flex>
                        <Flex flex='1' align='center' justify="center" style={{borderLeft: '1px solid #e7e7e7', height: '100%', paddingLeft: '20px'}}>
                            <span style={{opacity: 0.8}}>Sort By:</span>
                            <Select
                                defaultValue="Recent"
                                style={{ width: 200 }}
                                bordered={false}
                                onChange={handleChange}
                                options={[
                                    { value: 'Recent', label: 'Recent' },
                                    { value: 'Ratings: Low to High', label: 'Ratings: Low to High' },
                                    { value: 'Rating: High to Low', label: 'Rating: High to Low' },
                                ]}
                                />
                        </Flex>
                        <Flex flex='1' align='center' justify="center" style={{borderLeft: '1px solid #e7e7e7', height: '100%', paddingLeft: '20px'}}>
                            <span style={{opacity: 0.8}}>Sort By:</span>
                            <Select
                                defaultValue="Filter:"
                                style={{ width: 200 }}
                                bordered={false}
                                onChange={handleChange}
                                options={[
                                    { value: 'All Star', label: 'All Star' },
                                    { value: '5 Star', label: '5 Star' },
                                    { value: '4 Star', label: '4 Star' },
                                    { value: '3 Star', label: '3 Star' },
                                    { value: '2 Star', label: '2 Star' },
                                    { value: '1 Star', label: '1 Star' },
                                ]}
                                />
                        </Flex>
                    </Flex>
                    <Flex vertical justify="flex-end" >
                        {reviews.map((review) => 
                            <Flex className='ProductDetail--comment' justify="space-between" >
                                <Flex className="ProductDetail--comments__left" vertical gap="small">
                                    <Tag color="#009f7f" style={{fontSize: '16px',  padding: "5px 10px", width: 'fit-content', borderRadius: '20px'}}>{review.rating} <StarFilled /></Tag>
                                    <span style={{fontSize: '12px', opacity: 0.8}}>
                                        by {review.by}
                                        <CheckCircleFilled />
                                    </span>
                                    <span style={{padding: '10px 0', fontSize: '16px'}}>{review.comment}</span>
                                    <span style={{fontSize: '12px', opacity: 0.8}}>Date: {review.date}</span>
                                </Flex>
                                <Flex className="ProductDetail--right" align="flex-end" gap="large" style={{opacity: 0.6}}>
                                    <Flex className="ProductDetail--right--icon" align="center" gap="small"><LikeFilled />{review.likes}</Flex>
                                    <Flex className="ProductDetail--right--icon" align="center" gap="small"><DislikeFilled />{review.dislikes}</Flex>
                                    <span className="ProductDetail--right--icon"><BsThreeDotsVertical /></span>
                                </Flex>
                            </Flex>
                        )}
                        <Flex align="center" justify="space-between">
                            <span style={{fontSize: '12px', opacity: 0.6, padding: '20px'}}>Page 1 of 1</span>
                            <Pagination defaultCurrent={1} total={1} />
                        </Flex>
                    </Flex>
                </Flex> 
                <Flex className="ProductDetail--Related" vertical gap="large">
                    <span style={{fontWeight: "bolder", fontSize: "20px"}}>Related Products</span>
                <ProductList categoryId={"1"} />
            </Flex> 
        </div>
        </div>
    );
}