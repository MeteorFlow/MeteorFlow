import React,{useState} from 'react';
import { Layout, Divider,Typography,Input,Tabs,Radio, Form,Button,Col, Row, Table, Modal, Select, ConfigProvider } from 'antd';
import { GiftOutlined,CreditCardOutlined,DollarOutlined,WalletOutlined } from '@ant-design/icons';
import './Cart.css';
import "../../App.css";
import Navbar from '../../components/Navbar/Navbar';
import ProductCart, {Product} from '../../components/ProductCart/ProductCart'


const { Option } = Select;

const {Text} = Typography;
// Định nghĩa lại 
interface cartinfoData {
  name: string;
  address: string;
  email: string;
  phone: string;
  link: string;
}

interface seleccartData {
  TOTAL: number;
  amount: number;
  totalamount: number;
  totalship: number;
}

interface Voucher {
  ID: string;
  name: string;
  CouponDetail: string;
  Coupon: number;
}
// Đối tượng  chứa thông tin về user
const infoData: cartinfoData = {
  name: "Infouser",
  address: "R3 Royal City, số 72 Nguyễn Trãi, phường Thượng Đình, quận Thanh Xuân, Hà Nội.",
  email: "tanthenh123@gmail.com",
  phone: "0987456365",
  link: 'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4'
};

const initialProducts: Product[] = [
  {
    id: 1,
    name: 'Product 1',
    image:'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4',
    newPrice: 100,
    oldPrice: 120,
    quantity: 1,
    shop: 'Shop A',
    selected: false,
  },
  {
    id: 2,
    name: 'Product 2',
    image:'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4',
    newPrice: 100,
    oldPrice: 120,
    quantity: 2,
    shop: 'Shop b',
    selected: false,
  },
  {
    id: 3,
    name: 'Product 3',
    image:'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4',
    newPrice: 100,
    oldPrice: 120,
    quantity: 3,
    shop: 'Shop c',
    selected: false,
  },
  {
    id: 4,
    name: 'Product 3',
    image:'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4',
    newPrice: 100,
    oldPrice: 120,
    quantity: 3,
    shop: 'Shop c',
    selected: false,
  },
  {
    id: 4,
    name: 'Product 3',
    image:'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4',
    newPrice: 100,
    oldPrice: 120,
    quantity: 3,
    shop: 'Shop c',
    selected: false,
  },
  {
    id: 5,
    name: 'Product 3',
    image:'https://s3-alpha-sig.figma.com/img/58a8/2d3e/65a13ebb0f427c3cebd5e573e2ca455f?Expires=1702857600&Signature=NOkkOHPGWbjPxL3F-8Va7LeJKJuJY~JuNg18WJLCYM89OCdcZivbZpCYX6mdGaxGFWGhibjT918vh~2mP0Qvg8lTTjI~3Gm-uheipf6NS8s1eu7nxGQJk~hZi9TV0QtrndYVJJktVzqc4AIFqag9avavnZMtsXltvKWiSNZO6zyMJkQzmGTy3AcJVCDVW8c~ZV~4L6KeVa3-zTo4SU6Qt92HEQJh1Vq-yadYiIBpKR~mTpKIqdmMvAcNh6tjFvqUM6TqSZ4g2CSNxS1AuTJWJyDm~vGtz7Ea73EDLLC6PjbeaJyynjiyYvKjpCE9hNhif2CtK~7ybSw~xAHyaOqA1w__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4',
    newPrice: 100,
    oldPrice: 120,
    quantity: 3,
    shop: 'Shop c',
    selected: false,
  },
  // ... Add more products as needed
];

const totaldata: seleccartData = {
  TOTAL: 10,
  amount: 10,
  totalamount: 10,
  totalship: 10,
};

const { TabPane } = Tabs;

const Cart: React.FC = (Props) => {
  const [selectedProducts, setSelectedProducts] = useState<Product[]>(initialProducts);

  // Function to update selected products
  const updateSelectedProducts = (updatedProducts: Product[]) => {
    setSelectedProducts(updatedProducts);
  };

  // Tính lại totaldata.amount và totaldata.totalamount dựa trên selectedProducts
  const totalSelectedQuantity = selectedProducts.reduce((total, product) => total + (product.selected ? product.quantity : 0), 0);
  const totalSelectedValue = selectedProducts.reduce((total, product) => total + (product.selected ? product.quantity * product.newPrice : 0), 0);

  const totaldata: seleccartData = {
    TOTAL: 10, // Giá trị TOTAL ban đầu của bạn
    amount: totalSelectedQuantity, // Số lượng sản phẩm được chọn
    totalamount: totalSelectedValue, // Tổng giá trị sản phẩm được chọn
    totalship: 10, // Giá trị totalship ban đầu của bạn
  };
   // Hàm để tính giá trị mới của TOTAL
   const calculateTotal = (): number => {
    return totaldata.totalamount + totaldata.totalship;
  };

  const newTotal = calculateTotal(); // Tính giá trị mới của TOTAL
  totaldata.TOTAL = newTotal;

  const [value, setValue] = useState<number>(1);
  const [form] = Form.useForm();

  const onChange = (e: any) => {
    setValue(e.target.value);
  };

  const handleFormSubmit = (values: any) => {
    console.log('Submitted values:', values);
  };
  
  //vocher
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [selectedVoucher, setSelectedVoucher] = useState<string | null>(null);
  const [vouchers, setVouchers] = useState<Voucher[]>([]); // Danh sách các voucher

  // Mẫu dữ liệu voucher
  // Tạo 15 đối tượng Voucher với các giá trị khác nhau
  const sampleVouchers: Voucher[] = Array.from({ length: 15 }, (_, index) => ({
    ID: `ABC${index + 1}`,
    name: `Voucher ${String.fromCharCode(65 + index)}`,
    CouponDetail: `Giảm ${Math.floor(Math.random() * 100)}%`,
    Coupon: Math.random() * 0.9 + 0.1, // Giá trị ngẫu nhiên từ 0.1 đến 1.0
  }));

  // Mỗi khi component được khởi chạy, ta sẽ set danh sách voucher từ mẫu dữ liệu
  useState(() => {
    setVouchers(sampleVouchers);
  });

  const handleApplyVoucher = () => {
    // Xử lý khi áp dụng voucher, có thể làm gì đó với selectedVoucher ở đây
    console.log('Voucher được áp dụng:', selectedVoucher);
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setSelectedVoucher(null);
    setIsModalVisible(false);
  };
  // với select
  // const handleVoucherChange = (value: string) => {
  //   setSelectedVoucher(value);
  // };
  const handleVoucherChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSelectedVoucher(e.target.value);
  };


  const renderTabContent = (key: string | number) => {
    switch (key) {
      case '1':
        return <p>Thanh toán bằng tiền mặt khi nhận hàng</p>;
      case '2':
        return (
          <Form form={form} onFinish={handleFormSubmit} layout="vertical">
            <Row gutter={16}>
              <Col span={12}>
                <Form.Item label="Card Number" name="cardNumber">
                  <Input />
                </Form.Item>
              </Col>
              <Col span={12}>
                <Form.Item label="Expiration" name="expiration">
                  <Input />
                </Form.Item>
              </Col>
            </Row>
            <Row gutter={16}>
              <Col span={12}>
                <Form.Item label="Enter Name Card" name="cardName">
                  <Input />
                </Form.Item>
              </Col>
              <Col span={12}>
                <Form.Item label="CVV Code" name="cvvCode">
                  <Input />
                </Form.Item>
              </Col>
            </Row>
            <Form.Item>
            <Button style={{wight:'100%', backgroundColor:'#009F7F'}} htmlType="submit">
                <Text strong  style={{ color: '#FFFFFF' }}>Submit</Text>
              </Button>
            </Form.Item>
          </Form>
        );
      case '3':
        return (
          <Form form={form} onFinish={handleFormSubmit}>
            <Form.Item label="Số ví điện tử" name="eWalletNumber">
              <Input />
            </Form.Item>
            <Form.Item label="Mật khẩu" name="password">
              <Input.Password />
            </Form.Item>
            <Form.Item>
            <Button style={{wight:'100%', backgroundColor:'#009F7F'}} htmlType="submit">
              <Text strong  style={{ color: '#FFFFFF' }}>Submit</Text>
              </Button>
            </Form.Item>
          </Form>
        );
      default:
        return null;
    }
  };

  return(
  <Layout direction="vertical" style={{position: 'absolute', width: '100%', minHeight:'100%'}}>
    <ConfigProvider
            theme={{
              token: {
                colorPrimary: '#009F7F',
              },
            }}
          >
      <Layout style={{ background: '#F3F4F6' }}>
        <div className="horizontalSections">
          <div className="section1">
            <img src={infoData.link} alt="Your Image" className="centeredImage" />
            <h4> {infoData.name}</h4>
            <Divider style={{ margin: '8px'}}/>
            <Text strong>Address</Text>
            <Text type="secondary"> {infoData.address}</Text>
            <Divider style={{ margin: '8px'}}/>
            <Text strong>Email</Text>
            <Text type="secondary"> {infoData.email}</Text>
            <Divider style={{ margin: '8px'}}/>
            <Text strong>Phone</Text>
            <Text type="secondary"> {infoData.phone}</Text>

          </div>
          <div className="section2">
          <ProductCart initialProducts={initialProducts} updateSelectedProducts={updateSelectedProducts} />
          </div>
          <div className="section3">
            <div className="box">
              <div className="leftColumn">
                <Text strong type="secondary">Total Amount:</Text>
                <Text strong type="secondary">Amount:</Text>
                <Text strong type="secondary">Shipping Fee:</Text>
              </div>
              <div className="rightColumn">
                <Text strong>{totaldata.totalamount} </Text>
                <Text strong> ${totaldata.amount}</Text>
                <Text strong> ${totaldata.totalship}</Text>
              </div>
            </div>

            <div className="box" style={{padding: '10px 30px'}}>
              <div className="leftColumn">
                <Text strong >TOTAL:</Text>
              </div>
              <div className="rightColumn">
                <Text strong> ${totaldata.TOTAL}</Text>
              </div>
            </div>

            <Text strong > Apply voucher </Text>
              <Button size="large" style={{ margin: '10px 0 10px 0'}} onClick={() => setIsModalVisible(true) } >
                <Text strong style={{ color:'#009F7F' }}> Apply voucher </Text>
              </Button>
                <Modal
                  title="Danh sách voucher của bạn"
                  visible={isModalVisible}
                  onCancel={handleCancel}
                  footer={[
                    <Button key="cancel" onClick={handleCancel}>
                      Hủy
                    </Button>,
                    <Button key="apply" type="primary" onClick={handleApplyVoucher}>
                      Áp dụng
                    </Button>,
                  ]}
                  className="customModal"
                >
                  {/* <Select
                    style={{ width: '100%' }}
                    placeholder="Chọn voucher"
                    onChange={handleVoucherChange}
                    value={selectedVoucher}
                  >
                    {vouchers.map((voucher) => (
                      <Option key={voucher.ID} value={voucher.name}>
                        {voucher.name}
                      </Option>
                    ))}
                  </Select> */}
                  <Radio.Group style={{ width: '98%'}} onChange={handleVoucherChange} value={selectedVoucher}>
                    {vouchers.map((voucher) => (
                      <div className='box'>
                          <div className="leftColumn">
                            <Radio key={voucher.ID} value={voucher.name}>
                              {voucher.name}
                            </Radio>
                          </div>
                          <div className="rightColumn">
                            <Text>{voucher.CouponDetail} </Text>
                          </div>
                      </div>
                    ))}
                  </Radio.Group>
                </Modal>
                {selectedVoucher && (
                  <div>
                    <div className='box' style={{padding: '10px 13px', margin: '0px 0 10px 0'}}>
                      <Text strong> Voucher được áp dụng: {selectedVoucher}</Text>
                    </div>
                  </div>
                )}
            <Text strong> Select Payment Method </Text>
            <div className='box' style={{padding: '10px 13px', margin: '10px 0 10px 0'}}>
              <Tabs activeKey={value.toString()} onChange={(key) => setValue(parseInt(key))}>
                <TabPane tab={<Radio disabled={value !== 1} value={1}><DollarOutlined /></Radio>} key="1">
                  {renderTabContent('1')}
                </TabPane>
                <TabPane tab={<Radio disabled={value !== 2} value={2}><CreditCardOutlined /></Radio>} key="2">
                  {renderTabContent('2')}
                </TabPane>
                <TabPane tab={<Radio disabled={value !== 3} value={3}><WalletOutlined /></Radio>} key="3">
                  {renderTabContent('3')}
                </TabPane>
              </Tabs>
            </div>
            <Button size="large" style={{ backgroundColor:'#009F7F'}}>
              <Text strong  style={{ color: '#FFFFFF' }}>TOTAL:${totaldata.TOTAL}</Text>
            </Button>
          </div>
        </div>
      </Layout>
    </ConfigProvider>
  </Layout>
  );

};

export default Cart;
