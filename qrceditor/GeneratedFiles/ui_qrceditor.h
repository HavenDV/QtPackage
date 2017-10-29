/********************************************************************************
** Form generated from reading UI file 'qrceditor.ui'
**
** Created by: Qt User Interface Compiler version 5.9.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_QRCEDITOR_H
#define UI_QRCEDITOR_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QFormLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_QrcEditor
{
public:
    QVBoxLayout *verticalLayout_2;
    QWidget *centralWidget;
    QHBoxLayout *horizontalLayout;
    QPushButton *addButton;
    QPushButton *removeButton;
    QSpacerItem *horizontalSpacer;
    QGroupBox *groupBox;
    QFormLayout *formLayout;
    QLabel *aliasLabel;
    QLineEdit *aliasText;
    QLabel *prefixLabel;
    QLineEdit *prefixText;
    QLabel *languageLabel;
    QLineEdit *languageText;
    QLabel *urlLabel;
    QLineEdit *urlText;

    void setupUi(QWidget *QrcEditor)
    {
        if (QrcEditor->objectName().isEmpty())
            QrcEditor->setObjectName(QStringLiteral("QrcEditor"));
        QrcEditor->resize(491, 381);
        verticalLayout_2 = new QVBoxLayout(QrcEditor);
        verticalLayout_2->setContentsMargins(6, 6, 6, 6);
        verticalLayout_2->setObjectName(QStringLiteral("verticalLayout_2"));
        centralWidget = new QWidget(QrcEditor);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        QSizePolicy sizePolicy(QSizePolicy::MinimumExpanding, QSizePolicy::MinimumExpanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(centralWidget->sizePolicy().hasHeightForWidth());
        centralWidget->setSizePolicy(sizePolicy);

        verticalLayout_2->addWidget(centralWidget);

        horizontalLayout = new QHBoxLayout();
        horizontalLayout->setObjectName(QStringLiteral("horizontalLayout"));
        addButton = new QPushButton(QrcEditor);
        addButton->setObjectName(QStringLiteral("addButton"));
        QSizePolicy sizePolicy1(QSizePolicy::Minimum, QSizePolicy::Fixed);
        sizePolicy1.setHorizontalStretch(0);
        sizePolicy1.setVerticalStretch(0);
        sizePolicy1.setHeightForWidth(addButton->sizePolicy().hasHeightForWidth());
        addButton->setSizePolicy(sizePolicy1);

        horizontalLayout->addWidget(addButton);

        removeButton = new QPushButton(QrcEditor);
        removeButton->setObjectName(QStringLiteral("removeButton"));

        horizontalLayout->addWidget(removeButton);

        horizontalSpacer = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        horizontalLayout->addItem(horizontalSpacer);


        verticalLayout_2->addLayout(horizontalLayout);

        groupBox = new QGroupBox(QrcEditor);
        groupBox->setObjectName(QStringLiteral("groupBox"));
        formLayout = new QFormLayout(groupBox);
        formLayout->setObjectName(QStringLiteral("formLayout"));
        formLayout->setSizeConstraint(QLayout::SetMinAndMaxSize);
        formLayout->setFieldGrowthPolicy(QFormLayout::ExpandingFieldsGrow);
        aliasLabel = new QLabel(groupBox);
        aliasLabel->setObjectName(QStringLiteral("aliasLabel"));

        formLayout->setWidget(0, QFormLayout::LabelRole, aliasLabel);

        aliasText = new QLineEdit(groupBox);
        aliasText->setObjectName(QStringLiteral("aliasText"));

        formLayout->setWidget(0, QFormLayout::FieldRole, aliasText);

        prefixLabel = new QLabel(groupBox);
        prefixLabel->setObjectName(QStringLiteral("prefixLabel"));

        formLayout->setWidget(1, QFormLayout::LabelRole, prefixLabel);

        prefixText = new QLineEdit(groupBox);
        prefixText->setObjectName(QStringLiteral("prefixText"));

        formLayout->setWidget(1, QFormLayout::FieldRole, prefixText);

        languageLabel = new QLabel(groupBox);
        languageLabel->setObjectName(QStringLiteral("languageLabel"));

        formLayout->setWidget(2, QFormLayout::LabelRole, languageLabel);

        languageText = new QLineEdit(groupBox);
        languageText->setObjectName(QStringLiteral("languageText"));

        formLayout->setWidget(2, QFormLayout::FieldRole, languageText);

        urlLabel = new QLabel(groupBox);
        urlLabel->setObjectName(QStringLiteral("urlLabel"));

        formLayout->setWidget(3, QFormLayout::LabelRole, urlLabel);

        urlText = new QLineEdit(groupBox);
        urlText->setObjectName(QStringLiteral("urlText"));
        urlText->setReadOnly(true);

        formLayout->setWidget(3, QFormLayout::FieldRole, urlText);


        verticalLayout_2->addWidget(groupBox);


        retranslateUi(QrcEditor);

        QMetaObject::connectSlotsByName(QrcEditor);
    } // setupUi

    void retranslateUi(QWidget *QrcEditor)
    {
        addButton->setText(QApplication::translate("QrcEditor", "Add", Q_NULLPTR));
        removeButton->setText(QApplication::translate("QrcEditor", "Remove", Q_NULLPTR));
        groupBox->setTitle(QApplication::translate("QrcEditor", "Properties", Q_NULLPTR));
        aliasLabel->setText(QApplication::translate("QrcEditor", "Alias:", Q_NULLPTR));
        prefixLabel->setText(QApplication::translate("QrcEditor", "Prefix:", Q_NULLPTR));
        languageLabel->setText(QApplication::translate("QrcEditor", "Language:", Q_NULLPTR));
        urlLabel->setText(QApplication::translate("QrcEditor", "Resource URL:", Q_NULLPTR));
        Q_UNUSED(QrcEditor);
    } // retranslateUi

};

namespace Ui {
    class QrcEditor: public Ui_QrcEditor {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_QRCEDITOR_H
