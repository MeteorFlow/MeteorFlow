import { useState } from 'react';
import styles from './Navbar.module.css';
import '../../App.css';
import { ShoppingCartOutlined, UserOutlined } from '@ant-design/icons';
import { Input, ConfigProvider, InputProps, Modal } from 'antd';
import { NavLink } from 'react-router-dom';

interface SearchProps extends InputProps {
  inputPrefixCls?: string;
  onSearch?: (
    value: string,
    event?:
      | React.ChangeEvent<HTMLInputElement>
      | React.MouseEvent<HTMLElement, MouseEvent>
      | React.KeyboardEvent<HTMLInputElement>,
    info?: {
      source?: 'clear' | 'input';
    },
  ) => void;
  enterButton?: React.ReactNode;
  loading?: boolean;
}

const { Search } = Input;

const Navbar: React.FC = () => {
  const [searchValue, setSearchValue] = useState('');
  const [showModal, setShowModal] = useState(false);
  const [showNoDataModal, setShowNoDataModal] = useState(false);

  const handleSearch: SearchProps['onSearch'] = (value, _event, info) => {
    console.log(info?.source, value);
    if (value.trim() !== '') {
      performSearch(value);
    } else {
      setShowModal(true);
    }
  };

  const performSearch = (value: string) => {
    if (value.trim() !== '') {
      // Xử lý tìm kiếm ở đây và set lại state showNoDataModal nếu không có dữ liệu
      const searchResult = []; // Giả sử không có dữ liệu tìm kiếm phù hợp
      if (searchResult.length === 0) {
        setShowNoDataModal(true); // Hiển thị Modal nếu không có dữ liệu
      } else {
        setShowNoDataModal(false);
        // Xử lý dữ liệu tìm kiếm ở đây nếu có dữ liệu phù hợp
      }
    } else {
      setShowNoDataModal(false);
      console.log('Displaying default search results or message');
    }
  };

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value } = event.target;
    setSearchValue(value);
  };

  const closeModal = () => {
    setShowModal(false);
    setShowNoDataModal(false);
  };

  return (
    <nav className={styles['navbar']}>
      <NavLink to="/home" className={styles['navbar--link']}>Logo</NavLink>
      <ConfigProvider
        theme={{
          token: {
            colorPrimary: '#009F7F',
          },
        }}
      >
        <Search
          placeholder="Search your products from here"
          enterButton="Search"
          onSearch={handleSearch}
          onChange={handleChange}
          value={searchValue}
          style={{ width: 600 }}
          loading={false}
        />
        <Modal
          title="Warning"
          visible={showModal}
          onOk={closeModal}
          onCancel={closeModal}
          okText="OK"
          cancelText="Cancel"
        >
          <p>Please enter a search term.</p>
        </Modal>
        <Modal
          title="No Data Found"
          visible={showNoDataModal}
          onOk={closeModal}
          onCancel={closeModal}
          okText="OK"
          cancelText="Cancel"
        >
          <p>No data found for the entered search term.</p>
        </Modal>
      </ConfigProvider>
      <div className={styles['horizontal-list']}>
        <NavLink to="/shops" className={styles['navbar--link']}>Shops</NavLink>
        <NavLink to="/offer" className={styles['navbar--link']}>Offer</NavLink>
        <div>FAQ</div>
        <div>Contact</div>
      </div>
      <div className={styles['itemlist']}>
          <NavLink to="/cart" className={styles['navbar--link']}>
            <ShoppingCartOutlined style={{ fontSize: '18px', color: '#144832' }} />
          </NavLink>
          <NavLink to="/login" className={styles['navbar--link']}>
            <UserOutlined style={{ fontSize: '18px', color: '#144832' }} />
          </NavLink>
      </div>
    </nav>
  );
};

export default Navbar;