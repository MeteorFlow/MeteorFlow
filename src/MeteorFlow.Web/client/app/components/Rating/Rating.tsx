import { StarFilled } from "@ant-design/icons";
import { Flex, Progress, Rate, Tag } from "antd";
import "./Rating.css";

type RatingProps = {
    rate: {
        rating: number,
        ratingStar: number[],
        ratingNumber: number
    }
}
export const Rating: React.FC<RatingProps> = (props) => {
    const {rate: {rating, ratingStar, ratingNumber}} = props;
    return (
        <Flex className="Rating">
            <Flex className="Rating--total" vertical justify="center" align="center">
                <Tag color="#009f7f" style={{fontSize: '25px',  padding: "10px 15px", borderRadius: "30px"}}>{rating} <StarFilled /></Tag>
                <span style={{fontSize: '16px', opacity: '0.6', paddingTop: '10px'}}>{ratingNumber} ratings</span>
            
            </Flex>
            <Flex className="Rating--star" vertical justify="center" align="flex-start">
                {ratingStar.map((star, index) => {
                    const percent = star/ratingNumber*100;
                    return(
                        <Flex className="Rating--star__detail" justify="center" gap="small">
                            <Flex align="center" gap="3px" style={{fontWeight: 'bold', marginRight: "15px", opacity: "0.9"}}>{5-index} <StarFilled /></Flex>
                            <Progress percent={percent} showInfo={false} size="small" strokeColor="#009f7f" style={{marginBottom: "0px"}}/>
                            <span>{ratingStar[index]}</span>
                        </Flex>
                    )
                    }
                )}
            </Flex>
        </Flex>
    )
}