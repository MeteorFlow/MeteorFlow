import { CSSProperties, ChangeEvent, useState } from "react";
import { createSettings, updateSettings } from "../../services/appsettings";
import "./test.css";
import { AppSettings } from "../../models/settings";

type FormSettingProps = {
  settings?: AppSettings;
  handleSubmit: () => Promise<void>;
  className?: string;
  style?: CSSProperties;
};

export default function FormSetting({
  settings,
  handleSubmit,
  className,
  style,
}: FormSettingProps) {
  const [formInput, setFormInput] = useState<AppSettings>(settings ?? {});

  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    setFormInput({ ...formInput, [event.target.name]: event.target.value });
  };

  return (
    <div className={className} style={style}>
      <div
        style={{
          border: "1px solid black",
          padding: "0px 10px 10px 10px", 
          borderRadius: "10px",
          boxShadow: "0 0 10px 0 rgba(0, 0, 0, 0.2)",
        }}
      >
        <h1 style={{marginTop: "0px"}}>{settings ? "Edit" : "Add"} Setting</h1>
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            gap: "10px",
            paddingBottom: "10px",
          }}
        >
          {/* <div style={{display: "flex", flexDirection: "column", gap: "10px"}}>
                            <label htmlFor="key">Key</label>
                            <label htmlFor="value">Value</label>
                        </div>
                        <div style={{display: "flex", flexDirection: "column", gap: "10px"}}>
                            <input type="text" name="key" onChange={handleChange}/>
                            <input type="text" name="value" onChange={handleChange}/>
                        </div> */}
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <label htmlFor="name">Name</label>
            <input type="text" name="referenceKey" onChange={handleChange} />
          </div>
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <label htmlFor="value">Value</label>
            <input type="text" name="value" onChange={handleChange} />
          </div>
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <label htmlFor="description">Description</label>
            <input type="text" name="description" onChange={handleChange} />
          </div>
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <label htmlFor="type">Type</label>
            <input type="text" name="type" onChange={handleChange} />
          </div>
        </div>
        <button
          className="button"
          onClick={async () => {
            if (settings) await updateSettings([formInput]);
            else await createSettings(formInput);
            await handleSubmit();
          }}
        >
          Submit
        </button>
      </div>
    </div>
  );
}
